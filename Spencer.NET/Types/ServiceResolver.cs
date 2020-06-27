using System;

namespace Spencer.NET
{
    [Obsolete]
    public class ServiceResolver : IServiceResolver
    {
        public IServiceInstanceResolver InstanceResolver;
        
        public ServiceResolver(IServiceInstanceResolver instanceResolver)
        {
            InstanceResolver = instanceResolver;
        }

        [Obsolete]
        public object Resolve(IService service, IContainer container)
        {
            object instance = InstanceResolver.ResolveInstance(service, container);

            return instance;
        }
    }
}