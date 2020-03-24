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

        public ServiceInstanceCreator(IInstanceCreator instanceCreator, IServiceHasConstructorParametersChecker hasConstructorParametersChecker)
        {
            InstanceCreator = instanceCreator;
            HasConstructorParametersChecker = hasConstructorParametersChecker;
        }

        public object CreateInstance(IService service, IContainer container)
        {
            if (HasFactoryChecker.Check(service))
            {
                IFactory factory = FactoryProvider.ProvideFactory(service);
                FactoryInstanceCreator.CreateInstance(factory, service, container);
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

            throw new NotImplementedException();
        }
    }
}