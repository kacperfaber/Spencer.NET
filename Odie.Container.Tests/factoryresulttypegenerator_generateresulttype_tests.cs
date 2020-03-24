using System;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
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
            return new FactoryResultTypeGenerator(new FactoryResultExistChecker(new AttributesFinder()), new FactoryResultTypeProvider(new AttributesFinder()),
                    new MemberDeclarationTypeProvider(), new AssignableChecker())
                .GenerateResultType(typeof(TestClass).GetMembers().Where(x => x.Name.ToLower() == name.ToLower()).First());
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