using System;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
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
            return new FactoryResultTypeProvider(new AttributesFinder())
                .ProvideResultType(typeof(TestClass).GetMembers().Where(x => x.Name.ToLower() == name.ToLower()).First());
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