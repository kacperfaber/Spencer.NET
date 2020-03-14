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

        public void Register(ServicesList list, Service service, IContainer container)
        {
            if (!InstanceChecker.Check(service))
                InstanceProvider.ProvideInstance(service, container);
            
            list.AddService(service);
        }
    }
}