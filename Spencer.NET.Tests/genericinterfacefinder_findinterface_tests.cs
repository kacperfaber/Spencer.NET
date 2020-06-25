using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class genericinterfacefinder_findinterface_tests
    {
        class TestClass : ITest<int>, ITest<string>
        {
        }

        interface ITest<T>
        {
        }

        IService exec<T>()
        {
            TypedMemberValueProvider typedMemberValueProvider = new TypedMemberValueProvider();

            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new ServiceGenerator(
                    new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())),
                        new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new ServiceRegistrationFlagGenerator(new BaseTypeFinder(),
                        new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),
                            new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(),
                            new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                        new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator())), new ConstructorInfoListGenerator(),
                        new DefaultConstructorInfoProvider())),
                    new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(),
                    new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                        new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                            new ServiceHasConstructorParametersChecker()),
                        new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                            new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                        new ConstructorInfoListGenerator(), new ConstructorFinder(),
                        new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                        new ParametersValuesExtractor()))), new ServiceFactoryInvoker(),new ServiceDataGenerator()));
            IService[] services = generator.GenerateServices(typeof(TestClass), new AssemblyList(), null).ToArray();

            ServiceList list = new ServiceList();
            list.AddServices(services);

            IService @interface = new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()),
                    new InterfacesExtractor())
                .FindInterface(list,
                    typeof(T));

            return @interface;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest<int>>());
            Assert.DoesNotThrow(() => exec<ITest<string>>());
        }

        [Test]
        public void returns_not_null_target_exist_generic_argument()
        {
            Assert.NotNull(exec<ITest<int>>());
            Assert.NotNull(exec<ITest<string>>());
        }

        [Test]
        public void returns_null_if_gived_generic_arguments_was_not_registered()
        {
            Assert.Null(exec<ITest<bool>>());
        }

        [Test]
        public void returns_interfaces_with_targettype_equals_to_TestClass()
        {
            bool b = exec<ITest<int>>().Registration.TargetType == typeof(TestClass);
            bool b2 = exec<ITest<string>>().Registration.TargetType == typeof(TestClass);

            Assert.IsTrue(b && b2);
        }

        [Test]
        public void returns_service_has_2_interfaces()
        {
            Assert.IsTrue(exec<ITest<int>>().Registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface).Count() == 2);
            Assert.IsTrue(exec<ITest<string>>().Registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface).Count() == 2);
        }
    }
}