using System;

namespace Odie
{
    public class ServiceInfoGenerator : IServiceInfoGenerator
    {
        public ServiceInfo Generate(Type type)
        {
            ServiceInfoBuilder builder = new ServiceInfoBuilder();

            return builder
                .AddClass(type.IsClass)
                .AddInterface(type.IsInterface)
                .Build();
        }
    }
}