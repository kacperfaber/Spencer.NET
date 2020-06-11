using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ServiceRegistration : IServiceRegistration
    {
        public Type TargetType { get; set; }

        public IEnumerable<ServiceRegistrationFlag> RegistrationFlags { get; set; }

        public ServiceRegistration()
        {
            RegistrationFlags = new List<ServiceRegistrationFlag>();
        }
    }
}