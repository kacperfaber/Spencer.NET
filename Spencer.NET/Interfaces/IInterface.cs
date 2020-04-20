using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IInterface
    {
        Type Type { get; set; }
        
        bool HasGenericArguments { get; set; }
        
        IEnumerable<Type> GenericParameters { get; set; }
    }
}