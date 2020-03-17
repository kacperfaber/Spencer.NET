using System;

namespace Odie
{
    public class TypeServiceGenerator : ITypeServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IServiceInfoGenerator InfoGenerator;

        public TypeServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator,
            IServiceInfoGenerator infoGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
        }

        public Service GenerateService(Type @class, object instance = null)
        {
            ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
            ServiceInfo info = InfoGenerator.Generate(@class);
            IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance);
            
            return new ServiceBuilder()
                .AddFlags(flags)
                .AddInfo(info)
                .AddRegistration(registration)
                .Build();
        }
    }
}