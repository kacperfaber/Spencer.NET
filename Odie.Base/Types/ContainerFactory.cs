using Odie.Commons;

namespace Odie
{
    public class ContainerFactory
    {
        public static IContainer CreateContainer()
        {
            return new Container(
                new ServiceResolver(new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                    new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                        new ValueTypeActivator(), new TypeIsValueTypeChecker()))),
                new ServiceRegistrar(
                    new ServiceInstanceProvider(
                        new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                            new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                                new ValueTypeActivator(), new TypeIsValueTypeChecker())), new ServiceIsAutoValueChecker()), new ServiceInstanceChecker()),
                new ServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator()), new ServiceInfoGenerator()),
                new ServiceFinder(),
                new ServiceInitializer(new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                    new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                        new ValueTypeActivator(), new TypeIsValueTypeChecker()))), new TypeExisterChecker(), new ServiceIsAutoValueChecker(), new TypeGetter());
        }

        public static IContainer CreateContainer(FallbackConfiguration fallbackConfiguration)
        {
            Container container = new Container(
                new ServiceResolver(new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                    new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                        new ValueTypeActivator(), new TypeIsValueTypeChecker()))),
                new ServiceRegistrar(
                    new ServiceInstanceProvider(
                        new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                            new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                                new ValueTypeActivator(), new TypeIsValueTypeChecker())), new ServiceIsAutoValueChecker()), new ServiceInstanceChecker()),
                new ServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator()), new ServiceInfoGenerator()),
                new ServiceFinder(),
                new ServiceInitializer(new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                    new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                        new ValueTypeActivator(), new TypeIsValueTypeChecker()))), new TypeExisterChecker(), new ServiceIsAutoValueChecker(),
                new TypeGetter()) {FallbackConfiguration = fallbackConfiguration};

            return container;
        }
    }
}