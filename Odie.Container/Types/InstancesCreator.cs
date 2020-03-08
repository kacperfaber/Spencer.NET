using System;
using System.Reflection;

namespace Odie
{
    public class InstancesCreator
    {
        public static InstancesCreator Current = new InstancesCreator();
        
        public object CreateInstance(Type type, ServiceLoader loader)
        {
            ConstructorInfo ctor = ConstructorFinder.Current.GetConstructor(type);
            object[] parameters = ConstructorParametersGenerator.Current.GenerateParameters(ctor.GetParameters(), loader);

            return ctor.Invoke(parameters);
        }
    }
}