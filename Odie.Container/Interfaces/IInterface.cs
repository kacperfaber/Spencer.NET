using System;

namespace Odie
{
    public interface IInterface
    {
        Type Type { get; set; }
        
        bool IsGeneric { get; set; }
        
        Type[] GenericParameters { get; set; }
    }
}