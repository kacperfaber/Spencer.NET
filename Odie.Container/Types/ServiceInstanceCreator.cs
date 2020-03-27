using System;

namespace Odie
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