using System;
using System.Reflection;

namespace Odie
{
    public class InstancesCreator : IInstanceCreator
    {
        public IConstructorProvider ConstructorProvider;
        
        public object CreateInstance(ServiceFlags flags, Type type, object[] instances)
        {
            ConstructorInfo constructor = ConstructorProvider.ProvideConstructor(type, flags);
        }
    }
}