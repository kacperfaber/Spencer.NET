using System;
using System.Reflection;

namespace Odie
{
    public class InstancesCreator : IInstanceCreator
    {
        public IConstructorProvider ConstructorProvider;
        public IConstructorParametersGenerator ParametersGenerator;
        
        public object CreateInstance(ServiceFlags flags, Type type, object[] instances)
        {
            ConstructorInfo constructor = ConstructorProvider.ProvideConstructor(type, flags);
            ParametersGenerator
        }
    }
}