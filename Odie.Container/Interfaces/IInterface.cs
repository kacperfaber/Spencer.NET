using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IInterface
    {
        Type Type { get; set; }
        
        bool IsGeneric { get; set; }
        
        IEnumerable<Type> GenericParameters { get; set; }
    }
}