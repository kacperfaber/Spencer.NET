using System;

namespace Spencer.NET
{
    public class ServiceFactoryProvider : IServiceFactoryProvider
    {
        public IInstanceCreator InstanceCreator;

        public ServiceFactoryProvider(IInstanceCreator instanceCreator)
        {
            InstanceCreator = instanceCreator;
        }

        public IServiceFactory ProvideServiceFactory(Type @class, IReadOnlyContainer container)
        {
            return (IServiceFactory) InstanceCreator.CreateInstance(@class, container);
        }
    }
}