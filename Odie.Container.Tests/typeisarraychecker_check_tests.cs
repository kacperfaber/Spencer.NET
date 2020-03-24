using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class typeisarraychecker_check_tests
    {
        bool exec<T>()
        {
            TypeIsArrayChecker arrayChecker = new TypeIsArrayChecker();
            return arrayChecker.Check(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<int>());
        }

        [Test]
        public void returns_false_if_gived_is_int()
        {
            Assert.IsFalse(exec<int>());
        }

        [Test]
        public void returns_true_if_gived_is_array_of_ints()
        {
            Assert.IsTrue(exec<int[]>());
        }
    }
}