using System;

namespace Odie
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator)
        {
            FlagsGenerator = flagsGenerator;
        }

        public Service GenerateService(Type type)
        {
            using (ServiceBuilder builder = new ServiceBuilder())
            {
                ServiceFlags flags = FlagsGenerator.GenerateFlags(type);

                return builder
                    .AddFlags(flags)
                    .AddRegistration(RegistrationGenerator.Generate(flags, type))
                    .Build();
            }

            // TODO
        }
    }
}