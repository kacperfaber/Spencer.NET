using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class typegenericparametersprovider_providegenerictypes_tests
    {
        class Test1<T1, T2>
        {
        }

        class Test2
        {
        }

        List<Type> exec(Type type)
        {
            TypeGenericParametersProvider provider = new TypeGenericParametersProvider();
            IEnumerable<Type> types = provider.ProvideGenericTypes(type);

            return types.ToList();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(typeof(object)));
        }

        [Test]
        public void returns_object_and_int_if_gived_test1_is_object_and_int()
        {
            List<Type> args = exec(typeof(Test1<object, int>));

            Assert.IsTrue(args.First() == typeof(object));
            Assert.IsTrue(args.Last() == typeof(int));
        }

        [TestCase(typeof(object), typeof(object))]
        [TestCase(typeof(int), typeof(int))]
        [TestCase(typeof(object), typeof(float))]
        [TestCase(typeof(Test1<int, int>), typeof(Test1<object, int>))]
        [TestCase(typeof(ulong), typeof(double))]
        public void returns_excepted_result_using_testcase(Type t1, Type t2)
        {
            Type genericType = typeof(Test1<,>).MakeGenericType(t1, t2);

            List<Type> res = exec(genericType);

            Assert.IsTrue(res.First() == t1);
            Assert.IsTrue(res.Last() == t2);
        }

        [Test]
        public void returns_empty_when_gived_type_doesnt_contain_generic_args()
        {
            List<Type> res = exec(typeof(Test2));
            
            Assert.IsEmpty(res);
        }
    }
}