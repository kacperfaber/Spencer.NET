using System;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class factoryresultexistchecker_check_tests
    {
        class TestClass
        {
            [FactoryResult(typeof(void))]
            public static void Hello()
            {
            }

            public static void World()
            {
            }
        }

        bool exec(string name)
        {
            return new FactoryResultExistChecker(new AttributesFinder())
                .Check(typeof(TestClass).GetMembers().Where(x => x.Name.ToLower() == name.ToLower()).First());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec("hello"));
        }

        [Test]
        public void returns_true_if_target_was_Hello_method()
        {
            Assert.IsTrue(exec("hello"));
        }

        [Test]
        public void returns_false_if_target_was_World_method()
        {
            Assert.IsFalse(exec("world"));
        }
    }
}