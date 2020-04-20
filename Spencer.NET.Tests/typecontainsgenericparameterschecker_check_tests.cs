using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class typecontainsgenericparameterschecker_check_tests
    {
        class Test1<T>
        {
        }

        class Test2
        {
        }

        bool exec<T>()
        {
            TypeContainsGenericParametersChecker checker = new TypeContainsGenericParametersChecker();
            return checker.Check(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1<object>>());
        }

        [Test]
        public void returns_true_if_gived_is_test1()
        {
            Assert.IsTrue(exec<Test1<object>>());
        }

        [Test]
        public void returns_false_if_gived_is_test2()
        {
            Assert.IsFalse(exec<Test2>());
        }
    }
}