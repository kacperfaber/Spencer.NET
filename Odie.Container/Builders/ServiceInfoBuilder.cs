namespace Odie
{
    public class ServiceInfoBuilder : Builder<ServiceInfo, ServiceInfoBuilder>
    {
        public ServiceInfoBuilder(ServiceInfo o = default) : base(o)
        {
        }

        public ServiceInfoBuilder AddClass(bool isClass) => Update(x => x.IsClass = isClass);
        
        public ServiceInfoBuilder AddInterface(bool isInterface) => Update(x => x.IsInterface = isInterface);
    }
}