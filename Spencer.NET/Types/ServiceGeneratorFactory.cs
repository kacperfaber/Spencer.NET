namespace Spencer.NET
{
    public class ServiceGeneratorFactory
    {
        public static IServiceGenerator MakeInstance()
        {
            return new ServiceGenerator(
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
                    new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                        new ServiceHasConstructorParametersChecker()),
                    new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                        new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                    new ConstructorInfoListGenerator(), new ConstructorFinder(),
                    new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                    new ParametersValuesExtractor()))), new ServiceFactoryInvoker(), new ServiceDataGenerator());
        }
    }
}