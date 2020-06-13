using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class TypeRegistration
    {
        public Type Type { get; set; }

        public List<ServiceRegistrationFlag> RegistrationFlags { get; set; }

        public TypeRegistration()
        {
            RegistrationFlags = new List<ServiceRegistrationFlag>();
        }
    }
}