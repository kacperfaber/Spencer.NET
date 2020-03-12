using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public class ServiceRegistrationGenerator : IServiceRegistrationGenerator
    {
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        public IBaseTypeFinder BaseTypeFinder;
        public IInstanceCreator InstanceCreator;
        
        public IServiceRegistration Generate(ServiceFlags flags, Type type)
        {
            IEnumerable<Type> interfaces = InterfacesGenerator.GenerateInterfaces(flags, type);
            Type baseType = BaseTypeFinder.GetBaseType(type);


            return new ServiceRegistrationBuilder()
                .AddType(type)
                .AddBaseType(baseType)
                .SetInterfaces(interfaces)
                .Build();
        }
    }
}