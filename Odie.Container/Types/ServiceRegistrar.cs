using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public IServiceInstanceProvider InstanceProvider;

        public ServiceRegistrar(IServiceInstanceProvider instanceProvider)
        {
            InstanceProvider = instanceProvider;
        }

        public void Register(ref IEnumerable<Service> services, Service service, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            if (service.Info.IsClass)
            {
                InstanceProvider.ProvideInstance(service, resolver, registrar);

                Console.WriteLine($"type {service.Registration.TargetType} : {service.Registration.BaseType}\nimplementing {service.Registration.Interfaces.Count} interfaces\nwas registered.");

                List<Service> servicesList = services.ToList();
                servicesList.Add(service);

                services = servicesList;
            }

            else if (service.Info.IsInterface)
            {
                throw new NotImplementedException();
            }
        }
    }
}