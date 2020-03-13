using System;
using System.Collections.Generic;

namespace Odie
{
    public class Service : IService
    {
        public ServiceFlags Flags { get; set; }

        public IServiceRegistration Registration { get; set; }
        
        public IServiceInfo Info { get; set; }

        public Service()
        {
            Flags = new ServiceFlags();
        }
    }
}