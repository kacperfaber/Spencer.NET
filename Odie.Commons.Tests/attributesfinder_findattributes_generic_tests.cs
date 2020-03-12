using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Odie.Commons.Tests
{
    public class attributesfinder_findattributes_generic_tests
    {
        class Attr : Attribute
        {
        }

        class TestAttr : Attr
        {
        }

        class Test2Attr : Attr
        {
        }

        [Test2Attr]
        class TestClass
        {
        }

        IEnumerable<TAttribute> exec<TType, TAttribute>() where TAttribute : class
        {
            AttributesFinder finder = new AttributesFinder();
            IEnumerable<TAttribute> attributes = finder.FindAttributes<TAttribute>(typeof(TType));
            return attributes;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass, Attr>());
        }

        [Test]
        public void returns_excepted_len()
        {
            Assert.IsTrue(exec<TestClass, Attr>().Count() == 1);
        }

        [Test]
        public void returns_first_equals_test2attr()
        {
            Assert.AreEqual(exec<TestClass, Attr>().First().GetType(), typeof(Test2Attr));
        }

        [Test]
        public void returns_first_not_equals_testattr()
        {
            Assert.AreNotEqual(exec<TestClass, Attr>().First().GetType(), typeof(TestAttr));
        }
    }
}