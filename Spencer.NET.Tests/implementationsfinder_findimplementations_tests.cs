using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class implementationsfinder_findimplementations_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }
        
        Type[] exec<T>()
        {
            AssemblyList list = new AssemblyList();
            list.AddAssemblies(GetType().Assembly);

            ImplementationsFinder finder = new ImplementationsFinder(new TypeImplementsInterfaceValidator());
            IEnumerable<Type> implementations = finder.FindImplementations(list, typeof(T));

            return implementations.ToArray();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITestClass>());
        }

        [Test]
        public void returns_TestClass_if_target_was_ITestClass()
        {
            Type[] types = exec<ITestClass>();
            
            Assert.Contains(typeof(TestClass), types);
        }

        [Test]
        public void returns_single_item_if_target_was_ITestClass()
        {
            Assert.IsTrue(exec<ITestClass>().Count() == 1);
        }
    }
}