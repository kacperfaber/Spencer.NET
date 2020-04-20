using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicefactoryinvoker_invoke_tests
    {
        class Factory : IServiceFactory
        {
            public IService CreateService()
            {
                return new Service()
                {
                    Registration = new ServiceRegistration()
                    {
                        TargetType = typeof(int)
                    }
                };
            }
        }

        class ThrowFactory : IServiceFactory
        {
            public IService CreateService()
            {
                throw new Exception();
            }
        }

        object exec<T>() where T : IServiceFactory
        {
            IServiceFactory factory = (IServiceFactory) Activator.CreateInstance(typeof(T));

            ServiceFactoryInvoker invoker = new ServiceFactoryInvoker();
            object res = invoker.Invoke(factory);

            return res;
        }

        [Test]
        public void dont_throws_exceptions_when_gived_type_is_factory()
        {
            Assert.DoesNotThrow(() => exec<Factory>());
        }

        [Test]
        public void throws_exception_when_type_is_throwfactory()
        {
            Assert.That(exec<ThrowFactory>, Throws.Exception);
        }

        [Test]
        public void returns_typeof_Service_if_gived_type_is_factory()
        {
            Assert.AreEqual(typeof(Service), exec<Factory>().GetType());
        }

        [Test]
        public void returns_targettype_int_if_gived_type_is_factory()
        {
            IService service = (IService) exec<Factory>();
            
            Assert.AreEqual(typeof(int), service.Registration.TargetType);
        }
    }
}