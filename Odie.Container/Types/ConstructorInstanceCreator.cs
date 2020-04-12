using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ConstructorInstanceCreator : IConstructorInstanceCreator
    {
        public IConstructorProvider ConstructorProvider;
        public IConstructorParametersGenerator ParametersGenerator;
        public IConstructorInvoker ConstructorInvoker;
        public IConstructorInfoListGenerator ConstructorInfoListGenerator;
        public IConstructorFinder ConstructorFinder;
        public IConstructorListGenerator ConstructorListGenerator;
        public IParametersValuesExtractor ParametersValuesExtractor;

        public ConstructorInstanceCreator(IConstructorInvoker constructorInvoker, IConstructorParametersGenerator parametersGenerator, IConstructorProvider constructorProvider, IConstructorInfoListGenerator constructorInfoListGenerator, IConstructorFinder constructorFinder, IConstructorListGenerator constructorListGenerator, IParametersValuesExtractor parametersValuesExtractor)
        {
            ConstructorInvoker = constructorInvoker;
            ParametersGenerator = parametersGenerator;
            ConstructorProvider = constructorProvider;
            ConstructorInfoListGenerator = constructorInfoListGenerator;
            ConstructorFinder = constructorFinder;
            ConstructorListGenerator = constructorListGenerator;
            ParametersValuesExtractor = parametersValuesExtractor;
        }

        public object CreateInstance(ServiceFlags flags, Type @class, IReadOnlyContainer container)
        {
            IConstructor constructor = ConstructorProvider.ProvideConstructor(@class);
            IEnumerable<IParameter> parameters = ParametersGenerator.GenerateParameters(constructor, flags, container);
            object[] values = ParametersValuesExtractor.ExtractValues(parameters);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, values);

            return instance;
        }

        public object CreateInstance(Type @class, IReadOnlyContainer container)
        {
            IConstructor constructor = ConstructorProvider.ProvideConstructor(@class);
            IEnumerable<IParameter> parameters = ParametersGenerator.GenerateParameters(constructor, container);
            object[] values = ParametersValuesExtractor.ExtractValues(parameters);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, values);

            return instance;
        }

        public object CreateInstance(Type @class, IConstructorParameters constructorParameters)
        {
            ConstructorInfo[] constructorInfos = ConstructorInfoListGenerator.GenerateList(@class);
            IEnumerable<IConstructor> constructors = ConstructorListGenerator.GenerateList(constructorInfos);
            IConstructor constructor = ConstructorFinder.FindBy(constructors, constructorParameters);
            IEnumerable<IParameter> parameters = ParametersGenerator.GenerateParameters(constructor, constructorParameters);
            object[] values = ParametersValuesExtractor.ExtractValues(parameters);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, values);

            return instance;
        }
    }
}