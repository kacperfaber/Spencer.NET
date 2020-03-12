using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceBuilder : Builder<Service, ServiceBuilder>, IDisposable
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

        public ServiceBuilder AddType<T>()
        {
            return Update(x => x.Type = typeof(T));
        }

        public ServiceBuilder AddType(Type type)
        {
            return Update(x => x.Type = type);
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