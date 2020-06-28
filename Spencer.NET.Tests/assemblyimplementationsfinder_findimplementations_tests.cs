using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class assemblyimplementationsfinder_findimplementations_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        class Test2 : ITestClass
        {
        }

        class Test3 : ITestClass
        {
        }


        class Test4 : ITestClass
        {
        }


        IEnumerable<Type> exec<T>()
        {
            Type @interface = typeof(T);
            return new AssemblyImplementationsFinder().FindImplementations(@interface.Assembly, @interface);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITestClass>());
        }

        [Test]
        public void returns_TestClass_if_target_was_ITestClass()
        {
            Assert.NotNull(exec<ITestClass>().SingleOrDefault(x => x == typeof(TestClass)));
        }

        [Test]
        public void returns_assignable_to_gived_type()
        {
            IEnumerable<Type> types = exec<ITestClass>();

            foreach (Type type in types)
            {
                Assert.IsTrue(typeof(ITestClass).IsAssignableFrom(type));
            }
        }

        [Test]
        public void returns_expected_count()
        {
            Assert.IsTrue(exec<ITestClass>().Count() == 4);
        }
    }
}