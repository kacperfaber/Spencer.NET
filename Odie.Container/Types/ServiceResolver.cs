using System;

namespace Odie
{
    public class ServiceResolver : IServiceResolver
    {
        public IServiceInstanceResolver InstanceResolver;
        public IMemberValuesInjector ValuesInjector;
        
        public ServiceResolver(IServiceInstanceResolver instanceResolver, IMemberValuesInjector valuesInjector)
        {
            InstanceResolver = instanceResolver;
            ValuesInjector = valuesInjector;
        }

        public object Resolve(IService service, IContainer container)
        {
            object instance = InstanceResolver.ResolveInstance(service, container);
            ValuesInjector.InjectAll(service, container, instance);

            return instance;
        }
    }
}