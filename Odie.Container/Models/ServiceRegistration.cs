using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistration : IServiceRegistration
    {
        public Type TargetType { get; set; }
        public Type BaseType { get; set; }
        public List<Type> Interfaces { get; set; }
        public object Instance { get; set; }
        public bool HasGenericParameters { get; set; }
        public List<Type> GenericParameters { get; set; }
    }
}