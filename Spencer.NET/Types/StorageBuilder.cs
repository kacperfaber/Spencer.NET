using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class StorageBuilder : Builder<Storage, StorageBuilder>
    {
        public IServicesGenerator ServicesGenerator;
        public IServiceRegistrar ServiceRegistrar;

        public StorageBuilder RegisterType(Type type)
        {
            return Update(x =>
            {
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Object.Assemblies, null);
                ServiceRegistrar.Register(Object.Services, services);                
            });
        }
        
        
    }
}