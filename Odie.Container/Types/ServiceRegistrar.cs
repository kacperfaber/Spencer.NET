using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public IServiceInstanceProvider InstanceProvider;
        public IServiceInstanceChecker InstanceChecker;
        public IRegistratedServicesFilter RegistratedServicesFilter;

        public ServiceRegistrar(IServiceInstanceProvider instanceProvider, IServiceInstanceChecker instanceChecker, IRegistratedServicesFilter registratedServicesFilter)
        {
            InstanceProvider = instanceProvider;
            InstanceChecker = instanceChecker;
            RegistratedServicesFilter = registratedServicesFilter;
        }

        public void Register(IServiceList list, IEnumerable<IService> services, IContainer container)
        {
            IEnumerable<IService> filteredList = RegistratedServicesFilter.Filter(list, services);

            foreach (IService service in filteredList)
            {
                if (!InstanceChecker.Check(service))
                    InstanceProvider.ProvideInstance(service, container);
            
                list.AddService(service);
                Console.WriteLine("registering type " + service.Registration.TargetType.Name);
            }
        }
    }
}