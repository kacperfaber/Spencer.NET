using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceGenericRegistration
    {
        bool HasGenericParameters { get; set; }
        
        List<Type> GenericParameters { get; set; }
    }
}