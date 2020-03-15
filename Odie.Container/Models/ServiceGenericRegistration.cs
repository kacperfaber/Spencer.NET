using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceGenericRegistration : IServiceGenericRegistration
    {
        public bool HasGenericParameters { get; set; }
        public List<Type> GenericParameters { get; set; }
    }
}