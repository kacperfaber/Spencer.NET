using System;

namespace Spencer.NET
{
    public class ServiceInstanceCreator : IServiceInstanceCreator
    {
        public IObjectProducer ObjectProducer;

        public object CreateInstance(IService service, IContainer container)
        {
            throw new NotImplementedException();
        }
    }
}