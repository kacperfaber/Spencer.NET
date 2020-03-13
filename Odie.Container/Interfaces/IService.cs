using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IService
    {
        ServiceFlags Flags { get; set; }
        
        IServiceRegistration Registration { get; set; }
        
        IServiceInfo Info { get; set; }
    }
}