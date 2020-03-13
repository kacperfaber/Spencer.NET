using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class valuetypeactivator_activateinstance_tests
    {
        object exec<T>()
        {
            ValueTypeActivator a = new ValueTypeActivator();
            return a.ActivateInstance(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<int>());
        }

        [Test]
        public void returns_excepted_type()
        {
            Assert.IsTrue(exec<int>() is int);
            Assert.IsTrue(exec<double>() is double);
            Assert.IsTrue(exec<bool>() is bool);
            Assert.IsTrue(exec<float>() is float);
            Assert.IsTrue(exec<ulong>() is ulong);
        }

        [Test]
        public void returns_excepted_values_equals_to_default()
        {
            Assert.IsTrue((int) exec<int>() == default);
            Assert.IsTrue((float) exec<float>() == default);
            Assert.IsTrue((bool) exec<bool>() == default);
        }
    }
}