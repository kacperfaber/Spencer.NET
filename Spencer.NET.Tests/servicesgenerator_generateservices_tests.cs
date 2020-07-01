using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicesgenerator_generateservices_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        class ServiceFactory : IServiceFactory
        {
            public IService CreateService()
            {
                return null;
            }
        }

        class ThrowFactory : IServiceFactory
        {
            public IService CreateService()
            {
                throw new Exception();
            }
        }

        IEnumerable<IService> exec<T>(IReadOnlyContainer readOnlyContainer, IConstructorParameters parameters, object instance)
        {
            IServicesGenerator servicesGenerator = new ServicesGenerator(new TypeIsClassValidator(),
                new ImplementationsFinder(),
                ServiceGeneratorFactory.MakeInstance());

            return servicesGenerator.GenerateServices(typeof(T), new AssemblyList {GetType().Assembly}, readOnlyContainer, parameters, instance);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>(ContainerFactory.Container(), null, null));
        }

        [Test]
        public void returns_instance_is_IEnumerable_of_IService()
        {
            Assert.IsTrue(exec<TestClass>(ContainerFactory.Container(), null, null) is IEnumerable<IService>);
        }

        [Test]
        public void returns_single_IService_if_gived_was_TestClass()
        {
            Assert.IsTrue(exec<TestClass>(ContainerFactory.Container(), null, null).Count() == 1);
        }

        [Test]
        public void returns_single_IService_if_was_ITestClass_implemented_in_TestClass()
        {
            IContainer container = ContainerFactory.Container();
            IEnumerable<IService> services = exec<ITestClass>(container, null, null);

            Assert.IsTrue(services.Count() == 1);
        }

        [Test]
        public void dont_returns_null_IService_of_TestClass()
        {
            IEnumerable<IService> services = exec<TestClass>(ContainerFactory.Container(), null, null);

            Assert.IsEmpty(services.Where(x => x == null));
        }

        [Test]
        public void returns_any_null_IService_if_target_class_was_ServiceFactory()
        {
            IEnumerable<IService> services = exec<ServiceFactory>(ContainerFactory.Container(), null, null);

            Assert.IsEmpty(services.Where(x => x == null));
        }

        [Test]
        public void dont_throws_exception_if_Assert_Fail_was_throwed_in_CreateService_method()
        {
            exec<ThrowFactory>(ContainerFactory.Container(), null, null);
            Assert.Pass();
        }
    }
}