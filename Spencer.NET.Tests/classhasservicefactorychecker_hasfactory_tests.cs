using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class classhasservicefactorychecker_hasfactory_tests
    {
        class Yes : IServiceFactory
        {
            public IService CreateService()
            {
                throw new System.NotImplementedException();
            }
        }

        class No
        {
        }

        bool exec<T>()
        {
            return new ClassHasServiceFactoryChecker().HasFactory(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Yes>());
        }

        [Test]
        public void returns_true_if_gived_is_Yes_class()
        {
            Assert.IsTrue(exec<Yes>());
        }

        [Test]
        public void returns_false_if_gived_is_No_class()
        {
            Assert.IsFalse(exec<No>());
        }
    }
}