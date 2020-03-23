namespace Odie
{
    public class ContainerFactory
    {
        ContainerFactory()
        {
        }

        public static IContainer CreateContainer()
        {
            InstancesCreator instancesCreator = new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(), new ValueTypeActivator(),
                    new TypeIsValueTypeChecker(), new ConstructorParameterByTypeFinder()),
                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),new ConstructorGenerator()), new ConstructorInfoListGenerator(), new ConstructorFinder(),new ConstructorListGenerator()));

            return new Container(
                new ServiceResolver(
                    new ServiceInstanceResolver(new RegistrationInstanceIsNullChecker(), new AlwaysNewChecker(), new SingleInstanceChecker(),
                        new ServiceRegistrationInstanceSetter(), new ServiceInstanceCreator(instancesCreator, new ServiceHasConstructorParametersChecker())),
                    new MemberValuesInjector(new MemberValueSetter(),
                        new ValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(),
                            new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(),
                                new TypeContainsGenericParametersChecker()),
                            new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator())), new InjectFlagsProvider())),
                new ServiceRegistrar(new ServiceInstanceProvider(instancesCreator, new ServiceIsAutoValueChecker()), new ServiceInstanceChecker(),
                    new RegistratedServicesFilter()),
                new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                    new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                        new ServiceRegistrationGenerator(new BaseTypeFinder(),
                            new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider()),
                            new ServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                        new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(), new ServiceFactoryProvider(instancesCreator),
                        new ServiceFactoryInvoker())),
                new ServiceFinder(new TypeContainsGenericParametersChecker(), new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()), new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()), new TypeGenericParametersProvider())),
                    new ServiceByInterfaceFinder(), new ServiceByClassFinder(), new TypeIsClassValidator()),
                new ServiceInitializer(instancesCreator, new ServiceRegistrationInstanceSetter()),
                new TypeExisterChecker(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new ServiceIsAutoValueChecker(),
                new TypeGetter(), new AssemblyRegistrar(new AssemblyListAdder(), new AssemblyListContainsChecker()),
                new ConstructorParametersByObjectsGenerator(new TypeGetter()));
        }

        public static IContainer CreateContainer(FallbackConfiguration fallbackConfiguration)
        {
            Container container = (Container) CreateContainer();
            container.FallbackConfiguration = fallbackConfiguration;

            return container;
        }
    }
}