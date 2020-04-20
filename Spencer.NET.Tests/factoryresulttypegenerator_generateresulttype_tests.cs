using System;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class factoryresulttypegenerator_generateresulttype_tests
    {
        interface ITest
        {
        }

        class TestClass : ITest
        {
            [FactoryResult(typeof(TestClass))]
            public static ITest Hello() => new TestClass();

            [FactoryResult(typeof(TestClass))]
            public static int World() => 0;

            public static string Main() => "";
        }

        Type exec(string name)
        {
            IMember member = new MemberGenerator(new MemberFlagsGenerator()).GenerateMember(typeof(TestClass).GetMembers().Where(x => x.Name.ToLower() == name.ToLower()).First());

            return new FactoryResultTypeGenerator(new FactoryResultExistChecker(new AttributesFinder()), new FactoryResultTypeProvider(new AttributesFinder()),
                    new MemberDeclarationTypeProvider(), new AssignableChecker())
                .GenerateResultType(member);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec("hello"));
        }

        [Test]
        public void returns_typeof_TestClass_if_target_method_is_Hello()
        {
            Assert.IsTrue(exec("hello") == typeof(TestClass));
        }

        [Test]
        public void returns_typeof_int_if_target_is_World()
        {
            Assert.IsTrue(exec("world") == typeof(int));
        }

        [Test]
        public void returns_typeof_string_if_target_is_Main()
        {
            Assert.IsTrue(exec("Main") == typeof(string));
        }
    }
}