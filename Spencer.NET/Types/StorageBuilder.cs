using System;

namespace Spencer.NET
{
    public class StorageBuilder : Builder<Storage, StorageBuilder>
    {
        public IServicesGenerator ServicesGenerator;
        public IServiceRegistrar ServiceRegistrar;
        
        public StorageBuilder RegisterType(Type type)
        {
            ServicesGenerator.GenerateServices(type,base.Object.Assemblies,)
            return Update(x => x.Services.AddService(service));
        }              
    }
}