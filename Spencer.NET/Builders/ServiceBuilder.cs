using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceBuilder : Builder<Service, ServiceBuilder, IService>, IDisposable
    {
        public ServiceBuilder(Service o = null) : base(o)
        {
        }

        public ServiceBuilder AddFlag(string name, object value)
        {
            return Update(x => x.Flags.Add(new ServiceFlag(name, value)));
        }

        public ServiceBuilder AddFlag(ServiceFlag flag)
        {
            return Update(x => x.Flags.Add(flag));
        }

        public ServiceBuilder AddData(IServiceData data)
        {
            return Update(x => x.Data = data);
        }

        public ServiceBuilder RemoveFlag(Func<ServiceFlags, ServiceFlag> func)
        {
            return Update(x => x.Flags.Remove(func(x.Flags)));
        }

        public ServiceBuilder AddFlags(params ServiceFlag[] flags)
        {
            return Update(x => x.Flags.AddRange(flags));
        }

        public ServiceBuilder AddFlags(IEnumerable<ServiceFlag> flags)
        {
            return Update(x => x.Flags.AddRange(flags));
        }

        public ServiceBuilder AddRegistration(IServiceRegistration registration)
        {
            return Update(x => x.Registration = registration);
        }

        public ServiceBuilder AddInfo(IServiceInfo serviceInfo)
        {
            return Update(x => { });
        }

        public ServiceBuilder FromType(Type type)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}