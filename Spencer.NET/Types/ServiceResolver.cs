using System;

namespace Spencer.NET
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

        [Obsolete]
        public object Resolve(IService service, IContainer container)
        {
            object instance = InstanceResolver.ResolveInstance(service, container);

            return instance;
        }
    }
}