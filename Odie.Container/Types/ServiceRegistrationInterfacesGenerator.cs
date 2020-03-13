using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrationInterfacesGenerator : IServiceRegistrationInterfacesGenerator
    {
        public IEnumerable<Type> GenerateInterfaces(ServiceFlags flags, Type type)
        {
            Type[] interfaces = type.GetInterfaces();

            foreach (Type i in interfaces)
            {
                if (!flags.HasFlag(ServiceFlagConstants.ExcludeType, i))
                {
                    yield return i;
                }
            }
        }
    }
}