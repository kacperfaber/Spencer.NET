using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        public IServiceRegistrationGenerator RegistrationGenerator;
        public IClassHasServiceFactoryChecker ClassHasFactoryChecker;
        public IServiceFactoryProvider FactoryProvider;
        public IServiceFactoryInvoker FactoryInvoker;
        public IServiceDataGenerator DataGenerator;
        public IServiceFactoryResultValidator ResultValidator;
        public IServiceFactoryResultServiceExtractor ServiceFactoryResultServiceExtractor;

        public ServiceGenerator(IServiceFlagsGenerator flagsGenerator, IServiceRegistrationGenerator registrationGenerator, IClassHasServiceFactoryChecker classHasFactoryChecker, IServiceFactoryProvider factoryProvider, IServiceFactoryInvoker factoryInvoker, IServiceDataGenerator dataGenerator)
        {
            FlagsGenerator = flagsGenerator;
            RegistrationGenerator = registrationGenerator;
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
                IServiceFactoryResult factoryResult = FactoryInvoker.Invoke(factory);
                
                if (ResultValidator.Validate(factoryResult))
                {
                    return ServiceFactoryResultServiceExtractor.ExtractService(factoryResult);
                }
            }
            
            ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
            IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance, constructorParameters);
            
            return new ServiceBuilder()
                .AddFlags(flags)
                .AddData(DataGenerator.GenerateData(registration))
                .AddRegistration(registration)
                .Build(); 
        }

        public IService GenerateService(IServiceRegistration registration)
        {
            ServiceFlags emptyFlags = FlagsGenerator.GenerateEmpty();
            IServiceData data = DataGenerator.GenerateData(registration);

            return new ServiceBuilder()
                .AddFlags(emptyFlags)
                .AddRegistration(registration)
                .AddData(data)
                .Build();
        }

        public IService GenerateService(Type @class, IEnumerable<ServiceRegistrationFlag> flags)
        {
            IServiceRegistration registration = RegistrationGenerator.Generate(@class, flags);
            ServiceFlags emptyFlags = FlagsGenerator.GenerateEmpty();
            IServiceData data = DataGenerator.GenerateData(registration);

            return new ServiceBuilder()
                .AddFlags(emptyFlags)
                .AddRegistration(registration)
                .AddData(data)
                .Build();
        }

        public IService GenerateService(Type @class, IReadOnlyContainer container, object instance = null, IConstructorParameters constructorParameters = null)
        {
            if (ClassHasFactoryChecker.HasFactory(@class))
            {
                IServiceFactory factory = FactoryProvider.ProvideServiceFactory(@class, container);
                IServiceFactoryResult factoryResult = FactoryInvoker.Invoke(factory);

                if (ResultValidator.Validate(factoryResult))
                {
                    return ServiceFactoryResultServiceExtractor.ExtractService(factoryResult);
                }
            }
            
            ServiceFlags flags = FlagsGenerator.GenerateFlags(@class);
            IServiceRegistration registration = RegistrationGenerator.Generate(flags, @class, instance, constructorParameters);
            
            return new ServiceBuilder()
                .AddFlags(flags)
                .AddData(DataGenerator.GenerateData(registration))
                .AddRegistration(registration)
                .Build();
        }
    }
}