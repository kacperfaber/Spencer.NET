using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrationInterfacesGenerator : IServiceRegistrationInterfacesGenerator
    {
        public IRegistrationInterfacesFilter Filter; 

        public ServiceRegistrationInterfacesGenerator(IRegistrationInterfacesFilter filter)
        {
            Filter = filter;
        }

        public IEnumerable<Type> GenerateInterfaces(ServiceFlags flags, Type type)
        {
            IEnumerable<Type> interfaces = Filter.Filter(type.GetInterfaces());

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