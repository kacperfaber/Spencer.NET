﻿namespace Spencer.NET
{
    public class ServiceInfoBuilder : Builder<ServiceInfo, ServiceInfoBuilder, IServiceInfo>
    {
        public ServiceInfoBuilder(ServiceInfo o = default) : base(o)
        {
        }

        public ServiceInfoBuilder AddClass(bool isClass) => Update(x => x.IsClass = isClass);
        
        public ServiceInfoBuilder AddInterface(bool isInterface) => Update(x => x.IsInterface = isInterface);
    }
}