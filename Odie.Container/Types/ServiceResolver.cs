using System;

namespace Odie
{
    public class ServiceResolver : IServiceResolver
    {
        public IServiceInstanceResolver InstanceResolver;
        public IMemberValuesInjector ValuesInjector;
        public IInstanceMembersValueInjector InstanceMembersValueInjector;
        
        public ServiceResolver(IServiceInstanceResolver instanceResolver, IMemberValuesInjector valuesInjector, IInstanceMembersValueInjector instanceMembersValueInjector)
        {
            InstanceResolver = instanceResolver;
            ValuesInjector = valuesInjector;
            InstanceMembersValueInjector = instanceMembersValueInjector;
        }

        public object Resolve(IService service, IContainer container)
        {
            object instance = InstanceResolver.ResolveInstance(service, container);
            
            ValuesInjector.InjectAll(service, container, instance);
            InstanceMembersValueInjector.InjectAll(service, instance);

            return instance;
            
            // TODO
            // IF SERVICERESOLVER CAN RETURN SERVICE, AND FILL VALUE IF NULL.
        }
    }
}