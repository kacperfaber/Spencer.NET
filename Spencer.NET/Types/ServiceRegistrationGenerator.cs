using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrationGenerator : IServiceRegistrationGenerator
    {
        public IServiceRegistrationFlagGenerator RegistrationFlagsGenerator;
        public IServiceRegistrationFlagOptymalizer FlagsOptymalizer;

        public ServiceRegistrationGenerator(IServiceRegistrationFlagGenerator registrationFlagsGenerator, IServiceRegistrationFlagOptymalizer flagsOptymalizer)
        {
            RegistrationFlagsGenerator = registrationFlagsGenerator;
            FlagsOptymalizer = flagsOptymalizer;
        }

        public IServiceRegistration Generate(ServiceFlags flags, Type type, object instance = null, IConstructorParameters constructorParameters = null)
        {
            return new ServiceRegistration()
            {
                TargetType = type,
                RegistrationFlags = FlagsOptymalizer.Optymalize(RegistrationFlagsGenerator.GenerateFlags(flags, type, instance, constructorParameters))
            };
        }

        public IServiceRegistration Generate(Type type, IEnumerable<ServiceRegistrationFlag> flags)
        {
            return new ServiceRegistration()
            {
                TargetType = type,
                RegistrationFlags = FlagsOptymalizer.Optymalize(flags)
            };
        }
    }
}