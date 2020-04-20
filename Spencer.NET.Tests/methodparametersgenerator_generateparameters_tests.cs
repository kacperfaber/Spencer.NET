using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class methodparametersgenerator_generateparameters_tests
    {
#pragma warning disable
        class TestClass
        {
            public static int Hello { get; set; }

            public static int World;

            public static void Method1(int x, object o, string h)
            {
            }

            public static void Method2(TestClass @class, TestClass @test)
            {
            }
        }
#pragma warning restore

        List<IParameter> exec(Func<MemberInfo[], MemberInfo> func)
        {
            MemberInfo member = func(typeof(TestClass).GetMembers());
            IMember m = new MemberGenerator(new MemberFlagsGenerator()).GenerateMember(member);
            IEnumerable<IParameter> parameters = new MethodParametersGenerator().GenerateParameters(m);

            return parameters.ToList();
        }


        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(b => b.First()));
        }

        [Test]
        public void dont_throws_exceptions_when_member_is_not_method()
        {
            Assert.DoesNotThrow(() => exec(b => b.First(x => x.MemberType == MemberTypes.Field)));
            Assert.DoesNotThrow(() => exec(b => b.First(x => x.MemberType == MemberTypes.Property)));
        }

        [Test]
        public void returns_empty_if_gived_member_is_not_method()
        {
            Assert.IsEmpty(exec(b => b.First(x => x.MemberType == MemberTypes.Field)).AsEnumerable());
            Assert.IsEmpty(exec(b => b.First(x => x.MemberType == MemberTypes.Property)).AsEnumerable());
        }

        [Test]
        public void returns_excepted_parameters_count_if_target_method_was_Method1()
        {
            List<IParameter> parameters = exec(b => b.FirstOrDefault(x => x.Name == "Method1"));
            
            Assert.IsTrue(parameters.Count() == 3);
        }

        [Test]
        public void returns_excepted_list_if_target_method_is_Method1()
        {
            List<IParameter> parameters = exec(b => b.FirstOrDefault(x => x.Name == "Method1"));
            List<Type> types = parameters.ConvertAll(x => x.Type);

            Assert.IsTrue(types.SequenceEqual(new List<Type>() {typeof(int), typeof(object), typeof(string)}));
        }
        
        [Test]
        public void returns_excepted_parameters_count_if_target_method_was_Method2()
        {
            List<IParameter> parameters = exec(b => b.FirstOrDefault(x => x.Name == "Method2"));
            
            Assert.IsTrue(parameters.Count() == 2);
        }

        [Test]
        public void returns_excepted_list_if_target_method_is_Method2()
        {
            List<IParameter> parameters = exec(b => b.FirstOrDefault(x => x.Name == "Method2"));
            List<Type> types = parameters.ConvertAll(x => x.Type);

            Assert.IsTrue(types.SequenceEqual(new List<Type>() {typeof(TestClass), typeof(TestClass)}));
        }
    }
}