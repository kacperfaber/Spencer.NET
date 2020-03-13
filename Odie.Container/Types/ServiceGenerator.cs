using System;

namespace Odie
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IServiceInfoGenerator InfoGenerator;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
        }

        public Service GenerateService(Type type)
        {
            using (ServiceBuilder builder = new ServiceBuilder())
            {
                ServiceFlags flags = FlagsGenerator.GenerateFlags(type);
                IServiceRegistration registration = RegistrationGenerator.Generate(flags, type);
                IServiceInfo info = InfoGenerator.Generate(type);

                return builder
                    .AddFlags(flags)
                    .AddRegistration(registration)
                    .AddInfo(info)
                    .Build();
            }
        }
    }
}