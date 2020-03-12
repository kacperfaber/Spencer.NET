using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IService
    {
        ServiceFlags Flags { get; set; }
        
        Type Type { get; set; }
        
        List<Type> RegisteredAs { get; set; }
    }
}