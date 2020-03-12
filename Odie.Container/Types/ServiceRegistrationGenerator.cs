using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrationGenerator : IServiceRegistrationGenerator
    {
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        
        public IServiceRegistration Generate(ServiceFlags flags, Type type)
        {
            IEnumerable<Type> interfaces = InterfacesGenerator.GenerateInterfaces(flags, type);
        }
    }
}