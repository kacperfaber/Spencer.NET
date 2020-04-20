using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistration : IServiceRegistration
    {
        public Type TargetType { get; set; }
        public Type BaseType { get; set; }
        public List<IInterface> Interfaces { get; set; }
        public IServiceGenericRegistration GenericRegistration { get; set; }
        public IConstructorParameters ConstructorParameter { get; set; }
    }
}