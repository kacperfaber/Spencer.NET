using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrationGenerator : IServiceRegistrationGenerator
    {
        public IServiceRegistrationInterfacesGenerator InterfacesGenerator;
        public IServiceRegistrationBaseTypeProvider BaseTypeProvider;
        public IInstanceCreator InstanceCreator;
        public IServiceGenericRegistrationGenerator ServiceGenericRegistrationGenerator;

        public ServiceRegistrationGenerator(IServiceRegistrationBaseTypeProvider baseTypeProvider, IServiceRegistrationInterfacesGenerator interfacesGenerator, IServiceGenericRegistrationGenerator serviceGenericRegistrationGenerator)
        {
            InterfacesGenerator = interfacesGenerator;
            ServiceGenericRegistrationGenerator = serviceGenericRegistrationGenerator;
            BaseTypeProvider = baseTypeProvider;
        }

        public IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IConstructorParameters constructorParameters = null)
        {
            IEnumerable<IInterface> interfaces = InterfacesGenerator.GenerateInterfaces(flags, type);
            
            IServiceGenericRegistration genericRegistration = ServiceGenericRegistrationGenerator.Generate(type);
            
            return new ServiceRegistrationBuilder()
                .AddGenericRegistration(genericRegistration)
                .AddRegisterParameters(constructorParameters)
                .AddType(type)
                .AddBaseType(BaseTypeProvider.ProvideBaseType(flags, type))
                .SetInterfaces(interfaces)
                .Build();
        }
    }
}