using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistration
    {
        Type TargetType { get; set; }
        
        Type BaseType { get; set; }
        
        List<Type> Interfaces { get; set; }
        
        object Instance { get; set; }

        IServiceGenericRegistration GenericRegistration { get; set; }

        IRegisterParameters RegisterParameter { get; set; }
    }
}