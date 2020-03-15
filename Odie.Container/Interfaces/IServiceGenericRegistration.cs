using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceGenericRegistration
    {
        bool HasGenericParameters { get; set; }
        
        List<Type> GenericParameters { get; set; }
    }
}