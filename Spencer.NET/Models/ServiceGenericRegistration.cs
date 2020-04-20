using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceGenericRegistration : IServiceGenericRegistration
    {
        public bool HasGenericParameters { get; set; }
        public List<Type> GenericParameters { get; set; }
    }
}