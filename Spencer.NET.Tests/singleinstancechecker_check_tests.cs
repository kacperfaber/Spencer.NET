using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class singleinstancechecker_check_tests
    {
        bool exec(Action<ServiceBuilder> action)
        {
            using ServiceBuilder builder = new ServiceBuilder();
            action(builder);

            return new SingleInstanceChecker()
                .Check(builder.Build());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(b => b.AddFlag(ServiceFlagConstants.SingleInstance, null)));
        }

        [Test]
        public void returns_true_when_gived_flag_contains_singleinstance()
        {
            bool res = exec(b => b.AddFlag(ServiceFlagConstants.SingleInstance, null));
            Assert.IsTrue(res);
        }

        [Test]
        public void returns_false_when_gived_flag_doesnt_contains_singleinstance()
        {
            bool res = exec(_ => { });
            Assert.IsFalse(res);
        }

        [Test]
        public void returns_false_when_gived_flag_is_multiinstance()
        {
            Assert.IsFalse(exec(b => b.AddFlag(ServiceFlagConstants.MultiInstance, null)));
        }
    }
}