using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicehasfactorychecker_check_tests
    {
        bool exec(string flagName)
        {
            ServiceFlags flags = new ServiceFlags();
            flags.AddFlag(flagName, null);

            Service service = new Service()
            {
                Flags = flags
            };
            
            return new ServiceHasFactoryChecker().Check(service);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(ServiceFlagConstants.ServiceFactory));
        }

        [TestCase("hello")]
        [TestCase("pozdrowienia")]
        [TestCase("do")]
        [TestCase("wiezienia")]
        public void returns_false_if_registered_flags_wasnt_servicefactory(string name)
        {
            Assert.IsFalse(exec(name));
        }
        
        
        [TestCase(ServiceFlagConstants.ServiceFactory)]
        public void returns_true_if_registered_flags_wasnt_servicefactory(string name)
        {
            Assert.IsTrue(exec(name));
        }
    }
}