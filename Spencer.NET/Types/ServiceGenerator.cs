using System;

namespace Spencer.NET
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IServiceInfoGenerator InfoGenerator;

        public IClassHasServiceFactoryChecker ClassHasFactoryChecker;
        public IServiceFactoryProvider FactoryProvider;
        public IServiceFactoryInvoker FactoryInvoker;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator,
            IServiceInfoGenerator infoGenerator, IClassHasServiceFactoryChecker classHasFactoryChecker, IServiceFactoryProvider factoryProvider, IServiceFactoryInvoker factoryInvoker)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
            ClassHasFactoryChecker = classHasFactoryChecker;
            FactoryProvider = factoryProvider;
            FactoryInvoker = factoryInvoker;
        }

        public IService GenerateService(Type @class, IReadOnlyContainer container, object instance = null, IConstructorParameters constructorParameters = null)
        {
            if (ClassHasFactoryChecker.HasFactory(@class))
            {
                IServiceFactory factory = FactoryProvider.ProvideServiceFactory(@class, container);
                return FactoryInvoker.Invoke(factory);
            }
            
            ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
            ServiceInfo info = InfoGenerator.Generate(@class);
            IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance, constructorParameters);
            
            return new ServiceBuilder()
                .AddFlags(flags)
                .AddInfo(info)
                .AddData(new ServiceData() {Instance = instance})
                .AddRegistration(registration)
                .Build();
        }
    }
}