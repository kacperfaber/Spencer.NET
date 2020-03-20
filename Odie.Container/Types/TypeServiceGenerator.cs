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
            IServiceInfoGenerator infoGenerator, IClassHasServiceFactoryChecker classHasFactoryChecker, IServiceFactoryProvider factoryProvider, IServiceFactoryInvoker factoryInvoker)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
            ClassHasFactoryChecker = classHasFactoryChecker;
            FactoryProvider = factoryProvider;
            FactoryInvoker = factoryInvoker;
        }

        public IService GenerateService(Type @class, IContainer container, object instance = null, IRegisterParameters registerParameters = null)
        {
            if (ClassHasFactoryChecker.HasFactory(@class))
            {
                IServiceFactory factory = FactoryProvider.ProvideServiceFactory(@class, container);
                return FactoryInvoker.Invoke(factory);
            }
            
            ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
            ServiceInfo info = InfoGenerator.Generate(@class);
            IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance, registerParameters);
            
            return new ServiceBuilder()
                .AddFlags(flags)
                .AddInfo(info)
                .AddRegistration(registration)
                .Build();
        }
    }
}