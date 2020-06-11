using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrationBuilder : Builder<ServiceRegistration, ServiceRegistrationBuilder, IServiceRegistration>
    {
        public ServiceRegistrationBuilder(ServiceRegistration model = null) : base(model)
        {
        }

        public ServiceRegistrationBuilder AddFlag(int name, object value)
        {
            return Update(x => x.RegistrationFlags.Add(new ServiceRegistrationFlag (name, value)));
        }
    }
}