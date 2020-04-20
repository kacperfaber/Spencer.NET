using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class parameterinfoisvaluetypechecker_check_tests
    {

        bool exec<T>()
        {
            TypeIsValueTypeChecker checker = new TypeIsValueTypeChecker();
            return checker.Check(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<int>());
        }

        [Test]
        public void returns_true_when_i_gave_valuetype()
        {
            Assert.IsTrue(exec<int>());
            Assert.IsTrue(exec<bool>());
            Assert.IsTrue(exec<float>());
        }

        [Test]
        public void returns_false_when_i_gave_no_valuetype()
        {
            Assert.IsFalse(exec<object>());
            Assert.IsFalse(exec<parameterinfoisvaluetypechecker_check_tests>());
        }
    }
}