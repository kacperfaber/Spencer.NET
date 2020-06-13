using System.Collections.Generic;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicebyinterfacefinder_findbyinterface_tests
    {
        interface ITest
        {
        }

        interface IDontRegister
        {
        }

        class Test1 : ITest
        {
        }

        class Test2
        {
        }

        IService exec<T>()
        {
            ServiceList list = new ServiceList();
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()), new ServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder(),new MemberGenerator(new MemberFlagsGenerator())), new ServiceFlagsIssuesResolver()), new ServiceRegistrationGenerator(new ServiceRegistrationFlagGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()), new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(), new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator())), new ConstructorInfoListGenerator(), new DefaultConstructorInfoProvider())), new ServiceInfoGenerator(),new ClassHasServiceFactoryChecker(), new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(), new ConstructorParametersGenerator(new TypedMemberValueProvider(),new ConstructorParameterByTypeFinder(), new ServiceHasConstructorParametersChecker()), new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),new ConstructorInfoListGenerator(), new ConstructorFinder(),new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),new ParametersValuesExtractor()))), new ServiceFactoryInvoker()));

            IEnumerable<IService> services1 = generator.GenerateServices(typeof(Test1), new AssemblyList(), null);
            IEnumerable<IService> services2 = generator.GenerateServices(typeof(Test2), new AssemblyList(), null);

            foreach (IService service in services1)
            {
                list.AddService(service);
            }

            foreach (IService service in services2)
            {
                list.AddService(service);
            }

            ServiceByInterfaceFinder finder = new ServiceByInterfaceFinder(new InterfacesExtractor(), new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()));
            return finder.FindByInterface(list, typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest>());
        }

        [Test]
        public void returns_service_with_test1_if_gived_interface_is_itest()
        {
            Assert.AreEqual(typeof(Test1), exec<ITest>().Registration.TargetType);
        }

        [Test]
        public void returns_null_if_gived_type_isnt_registered()
        {
            Assert.Null(exec<IDontRegister>());
        }
    }
}