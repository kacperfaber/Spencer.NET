using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrationGenerator : IServiceRegistrationGenerator
    {
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        public IBaseTypeFinder BaseTypeFinder;
        public IInstanceCreator InstanceCreator;
        public IServiceGenericRegistrationGenerator ServiceGenericRegistrationGenerator;

        public ServiceRegistrationGenerator(IBaseTypeFinder baseTypeFinder, IServiceRegistrationInterfacesGenerator interfacesGenerator, IServiceGenericRegistrationGenerator serviceGenericRegistrationGenerator)
        {
            BaseTypeFinder = baseTypeFinder;
            InterfacesGenerator = interfacesGenerator;
            ServiceGenericRegistrationGenerator = serviceGenericRegistrationGenerator;
        }

        public IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IRegisterParameters registerParameters = null)
        {
            IEnumerable<Type> interfaces = InterfacesGenerator.GenerateInterfaces(flags, type);
            
            Type baseType = BaseTypeFinder.GetBaseType(type);
            IServiceGenericRegistration genericRegistration = ServiceGenericRegistrationGenerator.Generate(type);
            
            return new ServiceRegistrationBuilder()
                .AddGenericRegistration(genericRegistration)
                .AddRegisterParameters(registerParameters)
                .AddType(type)
                .AddInstance(instance)
                .AddBaseType(baseType)
                .SetInterfaces(interfaces)
                .Build();
        }
    }
}