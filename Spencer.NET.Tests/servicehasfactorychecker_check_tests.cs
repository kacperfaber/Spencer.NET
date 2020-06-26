using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicehasfactorychecker_check_tests
    {
        bool exec()
        {
            Service service = new Service()
            {
                Registration = new ServiceRegistration()
                {
                    RegistrationFlags = new ServiceRegistrationFlag[1]
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.Factory, null)
                    }
                }
            };
            
            return new ServiceHasFactoryChecker().Check(service);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        public void returns_false_if_registered_flags_wasnt_servicefactory()
        {
            Assert.IsFalse(exec());
        }
        
        
        public void returns_true_if_registered_flags_wasnt_servicefactory()
        {
            Assert.IsTrue(exec());
        }
    }
}