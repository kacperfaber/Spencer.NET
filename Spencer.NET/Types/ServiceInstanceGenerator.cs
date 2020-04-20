using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceInstanceGenerator : IServiceInstanceGenerator
    {
        public IServiceHasFactoryChecker HasServiceFactoryChecker;
        public IFactoryProvider FactoryProvider;
        public IFactoryInstanceCreator FactoryInstanceCreator;
        public IConstructorParametersGenerator ConstructorParametersGenerator;
        public IConstructorInvoker ConstructorInvoker;
        public IParametersValuesExtractor ParametersValuesExtractor;
        public IServiceConstructorProvider ServiceConstructorProvider;

        public ServiceInstanceGenerator(IServiceHasFactoryChecker hasServiceFactoryChecker, IFactoryProvider factoryProvider, IFactoryInstanceCreator factoryInstanceCreator, IConstructorParametersGenerator constructorParametersGenerator, IConstructorInvoker constructorInvoker, IParametersValuesExtractor parametersValuesExtractor, IServiceConstructorProvider serviceConstructorProvider)
        {
            HasServiceFactoryChecker = hasServiceFactoryChecker;
            FactoryProvider = factoryProvider;
            FactoryInstanceCreator = factoryInstanceCreator;
            ConstructorParametersGenerator = constructorParametersGenerator;
            ConstructorInvoker = constructorInvoker;
            ParametersValuesExtractor = parametersValuesExtractor;
            ServiceConstructorProvider = serviceConstructorProvider;
        }

        public object GenerateInstance(IService service, IReadOnlyContainer container)
        {
            if (HasServiceFactoryChecker.Check(service))
            {
                IFactory factory = FactoryProvider.ProvideFactory(service);
                return FactoryInstanceCreator.CreateInstance(factory, service, container);
            }

            IConstructor constructor = ServiceConstructorProvider.ProvideConstructor(service);
            IEnumerable<IParameter> parameters = ConstructorParametersGenerator.GenerateParameters(constructor, service, container);
            object[] parametersValues = ParametersValuesExtractor.ExtractValues(parameters);
            return ConstructorInvoker.InvokeConstructor(constructor, parametersValues);
        }
    }
}