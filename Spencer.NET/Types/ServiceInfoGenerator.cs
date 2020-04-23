using System;

namespace Spencer.NET
{
    public class ServiceInfoGenerator : IServiceInfoGenerator
    {
        public ServiceInfo Generate(Type type)
        {
            ServiceInfoBuilder builder = new ServiceInfoBuilder();

            return (ServiceInfo) builder
                .AddClass(type.IsClass)
                .AddInterface(type.IsInterface)
                .Build();
        }
    }
}