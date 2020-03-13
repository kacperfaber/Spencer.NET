using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class InstancesCreator : IInstanceCreator
    {
        public IConstructorProvider ConstructorProvider;
        public IConstructorParametersGenerator ParametersGenerator;

        public InstancesCreator(IConstructorProvider constructorProvider, IConstructorParametersGenerator parametersGenerator)
        {
            ConstructorProvider = constructorProvider;
            ParametersGenerator = parametersGenerator;
        }

        public object CreateInstance(ServiceFlags flags, Type type, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            ConstructorInfo constructor = ConstructorProvider.ProvideConstructor(type, flags);
            IEnumerable<object> parameters = ParametersGenerator.GenerateParameters(constructor, flags, resolver, registrar);
            object instance = constructor.Invoke(parameters.ToArray());

            return instance;
        }
    }
}