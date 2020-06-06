using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceRegistration
    {
        public Type TargetType { get; set; }

        public List<ServiceRegistrationFlag> RegistrationFlags { get; set; }
    }
}