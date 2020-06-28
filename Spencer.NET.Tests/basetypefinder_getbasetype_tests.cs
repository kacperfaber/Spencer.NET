using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class basetypefinder_getbasetype_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        class TestClass2 : TestClass
        {
        }

        Type exec<T>() => new BaseTypeFinder().GetBaseType(typeof(T));

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_object_if_target_was_TestClass()
        {
            Assert.AreEqual(typeof(object), exec<TestClass>());
        }

        [Test]
        public void returns_TestClass_if_target_was_TestClass2()
        {
            Assert.AreEqual(typeof(TestClass), exec<TestClass2>());
        }
    }
}