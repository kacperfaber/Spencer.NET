using System;

namespace Odie
{
    public class ServiceDataBuilder : Builder<ServiceData, ServiceDataBuilder>, IDisposable
    {
        public ServiceDataBuilder(ServiceData model = null) : base(model)
        {
        }

        public ServiceDataBuilder AddInstance(object instance)
        {
            return Update(x => x.Instance = instance);
        }

        public ServiceDataBuilder Initialized(bool initialized)
        {
            return Update(x => x.Initialized = initialized);
        }

        public void Dispose()
        {
        }
    }
}