using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrationBuilder : Builder<ServiceRegistration, ServiceRegistrationBuilder, IServiceRegistration>
    {
        public ServiceRegistrationBuilder(ServiceRegistration model = null) : base(model)
        {
        }

        public ServiceRegistrationBuilder AddType(Type type) => Update(x => x.TargetType = type);
    }
}