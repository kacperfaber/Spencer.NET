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

        public ConstructorInstanceCreator(IConstructorInvoker constructorInvoker, IConstructorParametersGenerator parametersGenerator, IConstructorProvider constructorProvider)
        {
            ConstructorInvoker = constructorInvoker;
            ParametersGenerator = parametersGenerator;
            ConstructorProvider = constructorProvider;
        }

        public object CreateInstance(ServiceFlags flags, Type type, IContainer container)
        {
            ConstructorInfo constructor = ConstructorProvider.ProvideConstructor(type, flags);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, flags, container);
            object instance = ConstructorInvoker.InvokeConstructor(constructor, parameters);

            return instance;
        }
    }
}