namespace Spencer.NET
{
    public class ContainerFactory
    {
        ContainerFactory()
        {
        }

        public static IReadOnlyContainer ReadOnlyContainer() => ReadOnlyContainer(new Storage());

        public static IReadOnlyContainer ReadOnlyContainer(IStorage storage)
        {
            return new ReadOnlyContainer(storage,
                new ServiceFinder(new TypeContainsGenericParametersChecker(),
                    new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()),
                        new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()),
                            new InterfacesExtractor())),
                    new ServiceByInterfaceFinder(new InterfacesExtractor(),
                        new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer())), new ServiceByClassFinder(),
                    new TypeIsClassValidator()), new TypeGetter(),
                new ServiceInstanceResolver(new ServiceInstanceSetter(),
                    new ObjectProducer(
                        new ServiceInstanceGenerator(new ServiceHasFactoryChecker(),
                            new FactoryProvider(new FactoriesByTypeFilter(new AssignableChecker()),
                                new FactoriesProvider(new FactoryGenerator(new FactoryTypeGenerator(),
                                    new FactoryResultTypeGenerator(new FactoryTypeProvider(new AssignableChecker()), new FactoryResultAttributeProvider(),
                                        new AttributesFinder(), new MemberDeclarationTypeProvider()),
                                    new MethodParametersGenerator()))),
                            new FactoryInstanceCreator(new FactoryMethodInstanceCreator(new ParametersGenerator(new ParameterGenerator()),
                                new FactoryMethodInvoker(new ParametersValuesExtractor(), new ParametersValuesGenerator(new TypedMemberValueProvider())),
                                new MethodParametersGenerator())),
                            new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                                new ServiceHasConstructorParametersChecker()), new ConstructorInvoker(), new ParametersValuesExtractor(),
                            new ServiceConstructorProvider(new ConstructorInfoListGenerator(),
                                new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                                new ServiceHasConstructorParametersChecker(), new ConstructorFinder(),
                                new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                                    new ServiceHasConstructorParametersChecker()),
                                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                                    new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))))),
                        new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()),
                            new InjectMemberValuesInjector(new MemberValueSetter(), new InjectFlagsProvider(),
                                new MemberDeclarationTypeProvider(), new InjectValueProvider()), new TryInjectMemberValuesInjector(
                                new ServiceAttributeProvider(),
                                new MemberDeclarationTypeProvider(),
                                new MemberValueSetter(), new InjectValueProvider()),
                            new AutoMemberValuesInjector(new MemberDeclarationTypeProvider(), new ServiceAttributeProvider(),
                                new AutoValueGenerator(
                                    new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(),
                                        new TypeContainsGenericParametersChecker()),
                                    new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new TypeIsArrayChecker(),
                                    new ArrayGenerator(),
                                    new TypeIsValueTypeChecker(), new ValueTypeActivator()), new MemberValueSetter()))),
                    new ServiceHasToInitializeChecker(new AlwaysNewChecker())),
                new AssemblyRegistrar(new AssemblyListAdder(), new AssemblyListContainsChecker()),
                new ServiceRegistrar(new RegistratedServicesFilter()),
                new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(),
                    ServiceGeneratorFactory.MakeInstance()));
        }

        public static IContainer Container() => Container(new Storage());

        public static IContainer Container(IStorage storage)
        {
            TypedMemberValueProvider typedMemberValueProvider = new TypedMemberValueProvider();

            InstancesCreator instancesCreator = new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                    new ServiceHasConstructorParametersChecker()),
                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                    new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(), new ConstructorFinder(),
                new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ParametersValuesExtractor()));

            return new Container(storage ?? new Storage(),
                new ServiceRegistrar(new RegistratedServicesFilter()),
                new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(),
                    ServiceGeneratorFactory.MakeInstance()),
                new ServiceFinder(new TypeContainsGenericParametersChecker(),
                    new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()),
                        new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()),
                            new InterfacesExtractor())),
                    new ServiceByInterfaceFinder(new InterfacesExtractor(),
                        new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer())), new ServiceByClassFinder(),
                    new TypeIsClassValidator()),
                new ServiceInitializer(
                    new ObjectProducer(
                        new ServiceInstanceGenerator(new ServiceHasFactoryChecker(),
                            new FactoryProvider(new FactoriesByTypeFilter(new AssignableChecker()),
                                new FactoriesProvider(new FactoryGenerator(new FactoryTypeGenerator(),
                                    new FactoryResultTypeGenerator(new FactoryTypeProvider(new AssignableChecker()), new FactoryResultAttributeProvider(),
                                        new AttributesFinder(), new MemberDeclarationTypeProvider()),
                                    new MethodParametersGenerator()))),
                            new FactoryInstanceCreator(new FactoryMethodInstanceCreator(new ParametersGenerator(new ParameterGenerator()),
                                new FactoryMethodInvoker(new ParametersValuesExtractor(), new ParametersValuesGenerator(typedMemberValueProvider)),
                                new MethodParametersGenerator())),
                            new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                                new ServiceHasConstructorParametersChecker()), new ConstructorInvoker(), new ParametersValuesExtractor(),
                            new ServiceConstructorProvider(new ConstructorInfoListGenerator(),
                                new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                                new ServiceHasConstructorParametersChecker(), new ConstructorFinder(),
                                new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                                    new ServiceHasConstructorParametersChecker()),
                                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                                    new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))))),
                        new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()),
                            new InjectMemberValuesInjector(new MemberValueSetter(), new InjectFlagsProvider(),
                                new MemberDeclarationTypeProvider(), new InjectValueProvider()),
                            new TryInjectMemberValuesInjector(new ServiceAttributeProvider(), new MemberDeclarationTypeProvider(),
                                new MemberValueSetter(), new InjectValueProvider()),
                            new AutoMemberValuesInjector(new MemberDeclarationTypeProvider(), new ServiceAttributeProvider(),
                                new AutoValueGenerator(
                                    new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(),
                                        new TypeContainsGenericParametersChecker()),
                                    new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new TypeIsArrayChecker(),
                                    new ArrayGenerator(),
                                    new TypeIsValueTypeChecker(), new ValueTypeActivator()), new MemberValueSetter()))), new ServiceInstanceSetter()),
                new ServiceIsAutoValueChecker(), new TypeGetter(),
                new AssemblyRegistrar(new AssemblyListAdder(), new AssemblyListContainsChecker()),
                new ConstructorParametersByObjectsGenerator(new TypeGetter()),
                new ServiceInstanceResolver(new ServiceInstanceSetter(),
                    new ObjectProducer(
                        new ServiceInstanceGenerator(new ServiceHasFactoryChecker(),
                            new FactoryProvider(new FactoriesByTypeFilter(new AssignableChecker()),
                                new FactoriesProvider(new FactoryGenerator(new FactoryTypeGenerator(),
                                    new FactoryResultTypeGenerator(new FactoryTypeProvider(new AssignableChecker()), new FactoryResultAttributeProvider(),
                                        new AttributesFinder(), new MemberDeclarationTypeProvider()),
                                    new MethodParametersGenerator()))),
                            new FactoryInstanceCreator(new FactoryMethodInstanceCreator(new ParametersGenerator(new ParameterGenerator()),
                                new FactoryMethodInvoker(new ParametersValuesExtractor(), new ParametersValuesGenerator(typedMemberValueProvider)),
                                new MethodParametersGenerator())),
                            new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                                new ServiceHasConstructorParametersChecker()), new ConstructorInvoker(), new ParametersValuesExtractor(),
                            new ServiceConstructorProvider(new ConstructorInfoListGenerator(),
                                new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                                new ServiceHasConstructorParametersChecker(), new ConstructorFinder(),
                                new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                                    new ServiceHasConstructorParametersChecker()),
                                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                                    new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))))),
                        new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()),
                            new InjectMemberValuesInjector(new MemberValueSetter(), new InjectFlagsProvider(),
                                new MemberDeclarationTypeProvider(), new InjectValueProvider()),
                            new TryInjectMemberValuesInjector(new ServiceAttributeProvider(), new MemberDeclarationTypeProvider(),
                                new MemberValueSetter(), new InjectValueProvider()),
                            new AutoMemberValuesInjector(new MemberDeclarationTypeProvider(), new ServiceAttributeProvider(),
                                new AutoValueGenerator(
                                    new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(),
                                        new TypeContainsGenericParametersChecker()),
                                    new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new TypeIsArrayChecker(),
                                    new ArrayGenerator(),
                                    new TypeIsValueTypeChecker(), new ValueTypeActivator()), new MemberValueSetter()))),
                    new ServiceHasToInitializeChecker(new AlwaysNewChecker())));
        }
    }
}