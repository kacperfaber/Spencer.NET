namespace Odie
{
    public class ContainerFactory
    {
        ContainerFactory()
        {
        }

        public static IContainer CreateContainer()
        {
            TypedMemberValueProvider typedMemberValueProvider = new TypedMemberValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(), new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new ParameterHasDefaultValueChecker(), new ParameterDefaultValueProvider());

            InstancesCreator instancesCreator = new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                new ConstructorParametersGenerator(typedMemberValueProvider,new ConstructorParameterByTypeFinder(),new ServiceHasConstructorParametersChecker()),
            new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),
                new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(), new ConstructorFinder(),new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),new ParametersValuesExtractor()));


            return new Container(
                new ServiceRegistrar(new ServiceInstanceProvider(instancesCreator, new ServiceIsAutoValueChecker()), new ServiceInstanceChecker(),
                    new RegistratedServicesFilter()),
                new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                    new ServiceGenerator(
                        new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())),
                            new ServiceFlagsIssuesResolver()),
                        new ServiceRegistrationGenerator(new BaseTypeFinder(),
                            new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),
                                new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(),
                                new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                            new ServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                        new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(), new ServiceFactoryProvider(instancesCreator),
                        new ServiceFactoryInvoker())),
                new ServiceFinder(new TypeContainsGenericParametersChecker(),
                    new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()),
                        new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()))),
                    new ServiceByInterfaceFinder(), new ServiceByClassFinder(), new TypeIsClassValidator()),
                new ServiceInitializer(
                    new ObjectProducer(
                        new ServiceInstanceGenerator(new ServiceHasFactoryChecker(),
                            new FactoryProvider(new FactoriesByTypeFilter(new AssignableChecker()),
                                new FactoriesProvider(new FactoryGenerator(new FactoryTypeGenerator(),
                                    new FactoryResultTypeGenerator(new FactoryResultExistChecker(new AttributesFinder()),
                                        new FactoryResultTypeProvider(new AttributesFinder()), new MemberDeclarationTypeProvider(), new AssignableChecker()),
                                    new MethodParametersGenerator()))),
                            new FactoryInstanceCreator(new FactoryMethodInstanceCreator(new ParametersValuesGenerator(typedMemberValueProvider),
                                new FactoryMethodInvoker(new ParametersValuesExtractor()))),
                            new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),
                                new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                            new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),new ServiceHasConstructorParametersChecker()), new ConstructorInvoker(),new ParametersValuesExtractor()),
                        new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()),
                            new MemberValuesInjector(new MemberValueSetter(), typedMemberValueProvider, new InjectFlagsProvider(),
                                new MemberDeclarationTypeProvider()))), new ServiceInstanceSetter()),
                new TypeExisterChecker(new ServiceFinder(new TypeContainsGenericParametersChecker(),
                    new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()),
                        new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()))),
                    new ServiceByInterfaceFinder(), new ServiceByClassFinder(), new TypeIsClassValidator())), new ServiceIsAutoValueChecker(), new TypeGetter(),
                new AssemblyRegistrar(new AssemblyListAdder(), new AssemblyListContainsChecker()),
                new ConstructorParametersByObjectsGenerator(new TypeGetter()),
                new ServiceInstanceResolver(new ServiceInstanceSetter(),
                    new ObjectProducer(
                        new ServiceInstanceGenerator(new ServiceHasFactoryChecker(),
                            new FactoryProvider(new FactoriesByTypeFilter(new AssignableChecker()),
                                new FactoriesProvider(new FactoryGenerator(new FactoryTypeGenerator(),
                                    new FactoryResultTypeGenerator(new FactoryResultExistChecker(new AttributesFinder()),
                                        new FactoryResultTypeProvider(new AttributesFinder()), new MemberDeclarationTypeProvider(), new AssignableChecker()),
                                    new MethodParametersGenerator()))),
                            new FactoryInstanceCreator(new FactoryMethodInstanceCreator(new ParametersValuesGenerator(typedMemberValueProvider),
                                new FactoryMethodInvoker(new ParametersValuesExtractor()))),
                            new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),
                                new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                            new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),new ServiceHasConstructorParametersChecker()), new ConstructorInvoker(),new ParametersValuesExtractor()),
                        new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()),
                            new MemberValuesInjector(new MemberValueSetter(), typedMemberValueProvider, new InjectFlagsProvider(),
                                new MemberDeclarationTypeProvider()))), new ServiceHasToInitializeChecker(new AlwaysNewChecker())));
        }
    }
}