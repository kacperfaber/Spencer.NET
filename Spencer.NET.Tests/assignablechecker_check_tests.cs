using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class assignablechecker_check_tests
    {

        bool exec(Type type, Type assignableTo)
        {
            int x = 0;
            return new AssignableChecker().Check(type, assignableTo);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(typeof(int), typeof(int)));
        }

        [TestCase(typeof(int), typeof(object))]
        [TestCase(typeof(float), typeof(object))]
        [TestCase(typeof(int), typeof(ValueType))]
        [TestCase(typeof(string), typeof(object))]
        [TestCase(typeof(assignablechecker_check_tests), typeof(object))]
        public void returns_true_if_gived_was_good_parameters(Type type, Type assignableTo)
        {
            Assert.IsTrue(exec(type, assignableTo));
        }
        
        [TestCase(typeof(object), typeof(int))]
        [TestCase(typeof(object), typeof(float))]
        [TestCase(typeof(ValueType), typeof(assignablechecker_check_tests))]
        [TestCase(typeof(assignablechecker_check_tests), typeof(assemblylistadder_add_tests))]
        [TestCase(typeof(assemblylistadder_add_tests), typeof(assemblylistcontainschecker_contains_tests))]
        public void returns_false_gived_was_bad_parameters(Type type, Type assignableTo)
        {
            Assert.IsFalse(exec(type, assignableTo));
        }
    }
}