using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceInstanceGenerator : IServiceInstanceGenerator
    {
        public IServiceHasFactoryChecker HasServiceFactoryChecker;
        public IFactoryProvider FactoryProvider;
        public IFactoryInstanceCreator FactoryInstanceCreator;
        public IConstructorProvider ConstructorProvider;
        public IConstructorParametersGenerator ConstructorParametersGenerator;
        public IConstructorInvoker ConstructorInvoker;
        public IParametersValuesExtractor ParametersValuesExtractor;
        
        public ServiceInstanceGenerator(IServiceHasFactoryChecker hasServiceFactoryChecker, IFactoryProvider factoryProvider, IFactoryInstanceCreator factoryInstanceCreator, IConstructorProvider constructorProvider, IConstructorParametersGenerator constructorParametersGenerator, IConstructorInvoker constructorInvoker, IParametersValuesExtractor parametersValuesExtractor)
        {
            HasServiceFactoryChecker = hasServiceFactoryChecker;
            FactoryProvider = factoryProvider;
            FactoryInstanceCreator = factoryInstanceCreator;
            ConstructorProvider = constructorProvider;
            ConstructorParametersGenerator = constructorParametersGenerator;
            ConstructorInvoker = constructorInvoker;
            ParametersValuesExtractor = parametersValuesExtractor;
        }

        public object GenerateInstance(IService service, IContainer container)
        {
            if (HasServiceFactoryChecker.Check(service))
            {
                IFactory factory = FactoryProvider.ProvideFactory(service);
                return FactoryInstanceCreator.CreateInstance(factory, service, container);
            }

            IConstructor constructor = ConstructorProvider.ProvideConstructor(service);
            IEnumerable<IParameter> parameters = ConstructorParametersGenerator.GenerateParameters(constructor, service, container);
            object[] parametersValues = ParametersValuesExtractor.ExtractValues(parameters);
            return ConstructorInvoker.InvokeConstructor(constructor, parametersValues);
        }
    }
}