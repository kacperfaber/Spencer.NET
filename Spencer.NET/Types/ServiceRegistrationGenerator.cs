using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrationGenerator : IServiceRegistrationGenerator
    {
        public IServiceRegistrationFlagGenerator RegistrationFlagsGenerator;

        public ServiceRegistrationGenerator(IServiceRegistrationFlagGenerator registrationFlagsGenerator)
        {
            RegistrationFlagsGenerator = registrationFlagsGenerator;
        }
        
        public IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IConstructorParameters constructorParameters = null)
        {
            return new ServiceRegistration()
            {
                TargetType = type,
                RegistrationFlags = RegistrationFlagsGenerator.GenerateFlags(flags, type, instance, constructorParameters)
            };
        }

        public IServiceRegistration Generate(Type type, IEnumerable<ServiceRegistrationFlag> flags)
        {
            return new ServiceRegistration()
            {
                TargetType = type,
                RegistrationFlags = flags
            };
        }
    }
}