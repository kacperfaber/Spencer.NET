using Odie.Commons;

namespace Odie
{
    public class ContainerFactory
    {
        public static IContainer CreateContainer()
        {
            return new Container(
                new ServiceResolver(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                    new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                        new ValueTypeActivator(), new TypeIsValueTypeChecker()),
                    new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider())))),
                new ServiceRegistrar(
                    new ServiceInstanceProvider(
                        new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                            new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                                new ValueTypeActivator(), new TypeIsValueTypeChecker()),
                            new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()))), new ServiceIsAutoValueChecker()),
                    new ServiceInstanceChecker()),
                new ServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(),
                        new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator())),
                        new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                    new ServiceInfoGenerator()),
                new ServiceFinder(new TypeContainsGenericParametersChecker(), new GenericServiceFinder(new TypeGenericParametersProvider())),
                new ServiceInitializer(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                    new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(),
                        new ValueTypeActivator(), new TypeIsValueTypeChecker()),
                    new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()))), new ServiceRegistrationInstanceSetter()),
                new TypeExisterChecker(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new ServiceIsAutoValueChecker(),
                new TypeGetter());
        }

        public static IContainer CreateContainer(FallbackConfiguration fallbackConfiguration)
        {
            Container container = (Container) CreateContainer();
            container.FallbackConfiguration = fallbackConfiguration;

            return container;
        }
    }
}