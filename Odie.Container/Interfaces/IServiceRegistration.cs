using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistration
    {
        Type TargetType { get; set; }
        
        Type BaseType { get; set; }
        
        List<IInterface> Interfaces { get; set; }

        IServiceGenericRegistration GenericRegistration { get; set; }

        IConstructorParameters ConstructorParameter { get; set; }
    }
}