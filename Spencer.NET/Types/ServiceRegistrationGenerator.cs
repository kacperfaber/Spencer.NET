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
        public IServiceRegistrationFlagGenerator RegistrationFlagsGenerator;

        public ServiceRegistrationGenerator(IServiceRegistrationBaseTypeProvider baseTypeProvider, IServiceRegistrationInterfacesGenerator interfacesGenerator, IServiceGenericRegistrationGenerator serviceGenericRegistrationGenerator)
        {
            InterfacesGenerator = interfacesGenerator;
            ServiceGenericRegistrationGenerator = serviceGenericRegistrationGenerator;
            BaseTypeProvider = baseTypeProvider;
        }

        public IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IConstructorParameters constructorParameters = null)
        {
            
        }
    }
}