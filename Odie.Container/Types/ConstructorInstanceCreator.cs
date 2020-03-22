using System;
using System.Collections.Generic;
using System.Linq;
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

        public ConstructorInstanceCreator(IConstructorInvoker constructorInvoker, IConstructorParametersGenerator parametersGenerator, IConstructorProvider constructorProvider, IConstructorInfoListGenerator constructorInfoListGenerator, IConstructorFinder constructorFinder, IConstructorListGenerator constructorListGenerator)
        {
            ConstructorInvoker = constructorInvoker;
            ParametersGenerator = parametersGenerator;
            ConstructorProvider = constructorProvider;
            ConstructorInfoListGenerator = constructorInfoListGenerator;
            ConstructorFinder = constructorFinder;
            ConstructorListGenerator = constructorListGenerator;
        }

        public object CreateInstance(ServiceFlags flags, Type @class, IContainer container)
        {
            IConstructor constructor = ConstructorProvider.ProvideConstructor(@class, flags);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, flags, container);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }

        public object CreateInstance(Type @class, IContainer container)
        {
            IConstructor constructor = ConstructorProvider.ProvideConstructor(@class);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, container);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }

        public object CreateInstance(Type @class, IConstructorParameters constructorParameters)
        {
            ConstructorInfo[] constructorInfos = ConstructorInfoListGenerator.GenerateList(@class);
            IEnumerable<IConstructor> constructors = ConstructorListGenerator.GenerateList(constructorInfos);
            IConstructor constructor = ConstructorFinder.FindBy(constructors, constructorParameters);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, constructorParameters);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }
    }
}