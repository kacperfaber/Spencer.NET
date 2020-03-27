using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class servicehastonitializechecker_check_tests
    {

        bool exec(bool singleInstance, object instance)
        {
            ServiceData serviceDataBuilder = new ServiceDataBuilder()
                .AddInstance(instance)
                .Build();

            Service service = new ServiceBuilder()
                .AddData(serviceDataBuilder)
                .AddFlag(singleInstance ? ServiceFlagConstants.SingleInstance : ServiceFlagConstants.MultiInstance, null)
                .AddRegistration(null)
                .Build();

            ServiceHasToInitializeChecker checker = new ServiceHasToInitializeChecker(new AlwaysNewChecker());
            return checker.Check(service);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(true, null));
        }

        [Test]
        public void returns_true_if_service_is_singleinstance_and_instance_is_null()
        {
            Assert.IsTrue(exec(true, null));
        }

        [Test]
        public void returns_false_if_service_is_multiinstance_and_instance_is_null()
        {
            Assert.IsFalse(exec(false, null));
        }

        [Test]
        public void returns_false_if_service_is_singleinstance_and_instance_is_not_null()
        {
            Assert.IsFalse(exec(true, new object()));
        }

        [Test]
        public void returns_false_if_service_is_multiinstance_and_instance_is_not_null()
        {
            Assert.IsFalse(exec(false, new object()));
        }
    }
}