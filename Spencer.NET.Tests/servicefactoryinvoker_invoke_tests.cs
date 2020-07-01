using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicefactoryinvoker_invoke_tests
    {
        class IntFactory : IServiceFactory
        {
            public static IService Service = new Service
            {
                Registration = new ServiceRegistration()
                {
                    TargetType = typeof(int)
                }
            };

            public IService CreateService()
            {
                return Service;
            }
        }

        class ThrowFactory : IServiceFactory
        {
            public IService CreateService()
            {
                throw new Exception();
            }
        }

        class NullFactory : IServiceFactory
        {
            public IService CreateService() => null;
        }

        IServiceFactoryResult exec<T>() where T : IServiceFactory
        {
            IServiceFactory factory = (IServiceFactory) Activator.CreateInstance(typeof(T));

            ServiceFactoryInvoker invoker = new ServiceFactoryInvoker();
            object res = invoker.Invoke(factory);

            return (IServiceFactoryResult) res;
        }

        [Test]
        public void dont_throws_exceptions_when_gived_type_is_factory()
        {
            Assert.DoesNotThrow(() => exec<IntFactory>());
        }

        [Test]
        public void returns_ServiceFactoryResult_equals_to_null_if_factory_was_throw_something()
        {
            Assert.Null(exec<ThrowFactory>().Service);
        }

        [Test]
        public void dont_throws_exceptions_if_factory_throwed_exception()
        {
            Assert.That(exec<ThrowFactory>, Throws.Nothing);
        }

        [Test]
        public void returns_typeof_ServiceFactoryResult_if_gived_type_is_factory()
        {
            Assert.AreEqual(typeof(ServiceFactoryResult), exec<IntFactory>().GetType());
        }

        [Test]
        public void returns_ServiceFactoryResult_Service_is_not_null_if_gived_was_IntFactory()
        {
            Assert.NotNull(exec<IntFactory>().Service);
        }

        [Test]
        public void returns_ServiceFactoryResult_Service_equals_to_IntFactory_Service_field()
        {
            Assert.AreEqual(IntFactory.Service, exec<IntFactory>().Service);
        }

        [Test]
        public void returns_ServiceFactoryResult_null_if_factory_was_NullFactory()
        {
            Assert.Null(exec<NullFactory>().Service);
        }

        [Test]
        public void returns_targettype_int_if_gived_type_is_factory()
        {
            IService service = exec<IntFactory>().Service;

            Assert.AreEqual(typeof(int), service.Registration.TargetType);
        }
    }
}