using System;

namespace Odie
{
    public class TypeServiceGenerator : ITypeServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IServiceInfoGenerator InfoGenerator;

        public IClassHasServiceFactoryChecker ClassHasFactoryChecker;
        public IServiceFactoryProvider FactoryProvider;
        public IServiceFactoryInvoker FactoryInvoker;

        public TypeServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator,
            IServiceInfoGenerator infoGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
        }

        public Service GenerateService(Type @class, IContainer container, object instance = null)
        {
            if (ClassHasFactoryChecker.HasFactory(@class))
            {
                IServiceFactory factory = FactoryProvider.ProvideServiceFactory(@class, container);
            }
            
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