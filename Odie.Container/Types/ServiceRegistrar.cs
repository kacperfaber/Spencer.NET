using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public IServiceInstanceProvider InstanceProvider;
        public IServiceInstanceChecker InstanceChecker;

        public ServiceRegistrar(IServiceInstanceProvider instanceProvider, IServiceInstanceChecker instanceChecker)
        {
            InstanceProvider = instanceProvider;
            InstanceChecker = instanceChecker;
        }

        public void Register(ref IEnumerable<Service> services, Service service, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            if (!InstanceChecker.Check(service))
                InstanceProvider.ProvideInstance(service, resolver, registrar);
            
            List<Service> servicesList = services.ToList();
            servicesList.Add(service);

            services = servicesList;
        }
    }
}