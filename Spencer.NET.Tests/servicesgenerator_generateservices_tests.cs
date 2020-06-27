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

        IEnumerable<IService> exec<T>(IReadOnlyContainer readOnlyContainer, IConstructorParameters parameters, object instance)
        {
            IServicesGenerator servicesGenerator = new ServicesGenerator(new TypeIsClassValidator(),
                new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new ServiceGenerator(
                    new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())),
                        new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(
                        new ServiceRegistrationFlagGenerator(new BaseTypeFinder(),
                            new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),
                                new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(),
                                new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                            new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator())), new ConstructorInfoListGenerator(),
                            new DefaultConstructorInfoProvider()), new ServiceRegistrationFlagOptymalizer()),
                    new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(),
                    new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                        new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                            new ServiceHasConstructorParametersChecker()),
                        new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                            new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(),
                        new ConstructorFinder(), new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                        new ParametersValuesExtractor()))), new ServiceFactoryInvoker(), new ServiceDataGenerator()));

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
        public void returns_null_IService_if_target_class_was_ServiceFactory()
        {
            IEnumerable<IService> services = exec<ServiceFactory>(ContainerFactory.Container(), null, null);

            Assert.IsNotEmpty(services.Where(x => x == null));
        }

        
    }
}