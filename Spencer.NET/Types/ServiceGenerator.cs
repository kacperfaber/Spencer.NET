using System;
using System.Collections.Generic;

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
        public IServiceDataGenerator DataGenerator;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator,
            IServiceInfoGenerator infoGenerator, IClassHasServiceFactoryChecker classHasFactoryChecker, IServiceFactoryProvider factoryProvider, IServiceFactoryInvoker factoryInvoker, IServiceDataGenerator dataGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
            InfoGenerator = infoGenerator;
            ClassHasFactoryChecker = classHasFactoryChecker;
            FactoryProvider = factoryProvider;
            FactoryInvoker = factoryInvoker;
            DataGenerator = dataGenerator;
        }

        public IService GenerateService(Type @class, object instance = null, IConstructorParameters constructorParameters = null)
        {
            if (ClassHasFactoryChecker.HasFactory(@class))
            {
                IServiceFactory factory = FactoryProvider.ProvideServiceFactory(@class);
                return FactoryInvoker.Invoke(factory);
            }
            
            ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
            ServiceInfo info = InfoGenerator.Generate(@class);
            IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance, constructorParameters);
            
            return new ServiceBuilder()
                .AddFlags(flags)
                .AddInfo(info)
                .AddData(DataGenerator.GenerateData(registration))
                .AddRegistration(registration)
                .Build(); 
        }

        public IService GenerateService(IServiceRegistration registration)
        {
            ServiceFlags emptyFlags = FlagsGenerator.GenerateEmpty();
            ServiceInfo info = InfoGenerator.Generate(registration.TargetType);
            IServiceData data = DataGenerator.GenerateData(registration);

            return new ServiceBuilder()
                .AddFlags(emptyFlags)
                .AddRegistration(registration)
                .AddInfo(info)
                .AddData(data)
                .Build();
        }

        public IService GenerateService(Type @class, IEnumerable<ServiceRegistrationFlag> flags)
        {
            IServiceRegistration registration = RegistrationGenerator.Generate(@class, flags);
            ServiceFlags emptyFlags = FlagsGenerator.GenerateEmpty();
            ServiceInfo info = InfoGenerator.Generate(registration.TargetType);
            IServiceData data = DataGenerator.GenerateData(registration);

            return new ServiceBuilder()
                .AddFlags(emptyFlags)
                .AddRegistration(registration)
                .AddInfo(info)
                .AddData(data)
                .Build();
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
                .AddData(DataGenerator.GenerateData(registration))
                .AddRegistration(registration)
                .Build();
        }
    }
}