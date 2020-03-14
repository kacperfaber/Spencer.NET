using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class serviceflagsissuesresolver_resolveissues_tests
    {
        ServiceFlags exec(ServiceFlags flags)
        {
            ServiceFlagsIssuesResolver resolver = new ServiceFlagsIssuesResolver();
            resolver.ResolveIssues(flags);

            return flags;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(ServiceFlags.CreateNew()));
        }

        [Test]
        public void if_gived_serviceflags_was_singleinstance_and_multiinstance_returns_singleinstance_only()
        {
            ServiceFlags flags = ServiceFlags.CreateNew();
            flags.AddFlag(ServiceFlagConstants.MultiInstance, null);
            flags.AddFlag(ServiceFlagConstants.SingleInstance, null);

            ServiceFlags result = exec(flags);
            
            Assert.IsTrue(result.HasFlag(ServiceFlagConstants.SingleInstance));
            Assert.IsFalse(result.HasFlag(ServiceFlagConstants.MultiInstance));
        }

        [Test]
        public void if_gived_serviceflags_wasnt_had_singleinstance_or_multiinstance_returns_singleinstance()
        {
            ServiceFlags flags = ServiceFlags.CreateNew();
            Assert.IsFalse(flags.HasFlag(ServiceFlagConstants.SingleInstance));
            
            ServiceFlags result = exec(flags);
            Assert.IsTrue(result.HasFlag(ServiceFlagConstants.SingleInstance));
        }
    }
}