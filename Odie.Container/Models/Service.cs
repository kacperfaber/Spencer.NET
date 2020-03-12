using System;
using System.Collections.Generic;

namespace Odie
{
    public class Service : IService
    {
        public ServiceFlags Flags { get; set; }
        
        public Type Type { get; set; }
        
        public List<Type> RegisteredAs { get; set; }
    }
}