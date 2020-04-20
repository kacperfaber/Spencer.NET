using System;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class factoryresulttypeprovider_provideresulttype_tests
    {
        class TestClass
        {
            [FactoryResult(typeof(string))]
            public static void Hello()
            {
            }

            [FactoryResult(typeof(int))]
            public static void World()
            {
            }
        }

        Type exec(string name)
        {
            IMember member = new MemberGenerator(new MemberFlagsGenerator()).GenerateMember(
                typeof(TestClass).GetMembers().Where(x => x.Name.ToLower() == name.ToLower()).First());

            return new FactoryResultTypeProvider(new AttributesFinder())
                .ProvideResultType(member);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec("hello"));
        }

        [Test]
        public void returns_int_if_target_method_is_world()
        {
            Assert.IsTrue(exec("world") == typeof(int));
        }

        [Test]
        public void returns_void_if_target_method_is_hello()
        {
            Assert.IsTrue(exec("hello") == typeof(string));
        }
    }
}