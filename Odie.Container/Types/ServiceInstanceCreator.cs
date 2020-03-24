using System;

namespace Odie
{
    public class ServiceInstanceCreator : IServiceInstanceCreator
    {
        public IServiceHasConstructorParametersChecker HasConstructorParametersChecker;
        public IInstanceCreator InstanceCreator;
        public IServiceHasFactoryChecker HasFactoryChecker;
        public IFactoryInstanceCreator FactoryInstanceCreator;
        public IFactoryProvider FactoryProvider;

        public ServiceInstanceCreator(IInstanceCreator instanceCreator, IServiceHasConstructorParametersChecker hasConstructorParametersChecker, IFactoryProvider factoryProvider, IFactoryInstanceCreator factoryInstanceCreator, IServiceHasFactoryChecker hasFactoryChecker)
        {
            InstanceCreator = instanceCreator;
            HasConstructorParametersChecker = hasConstructorParametersChecker;
            FactoryProvider = factoryProvider;
            FactoryInstanceCreator = factoryInstanceCreator;
            HasFactoryChecker = hasFactoryChecker;
        }

        public object CreateInstance(IService service, IContainer container)
        {
            if (HasFactoryChecker.Check(service))
            {
                IFactory factory = FactoryProvider.ProvideFactory(service);
                object instance = FactoryInstanceCreator.CreateInstance(factory, service, container);

                return instance;
            }

            else
            {
                if (HasConstructorParametersChecker.Check(service))
                {
                    return InstanceCreator.CreateInstance(service.Registration.TargetType, service.Registration.ConstructorParameter);
                }

                else
                {
                    return InstanceCreator.CreateInstance(service.Registration.TargetType, container);
                }
            }
        }
    }
}