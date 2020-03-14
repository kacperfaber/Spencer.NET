using System;

namespace Odie
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IServiceInfoGenerator InfoGenerator;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator, IServiceInfoGenerator infoGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
        }

        public Service GenerateService(Type type, object instance = null)
        {
            using (ServiceBuilder builder = new ServiceBuilder())
            {
                ServiceFlags flags = FlagsGenerator.GenerateFlags(type);
                IServiceRegistration registration = RegistrationGenerator.Generate(flags, type, instance);
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