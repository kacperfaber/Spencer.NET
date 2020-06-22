using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class TypeRegistration
    {
        public List<ServiceRegistrationFlag> RegistrationFlags { get; set; }

        public TypeRegistration()
        {
            RegistrationFlags = new List<ServiceRegistrationFlag>();
        }
    }
}