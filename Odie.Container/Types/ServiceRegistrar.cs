﻿using System.Collections.Generic;

namespace Odie
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public IServiceInstanceProvider InstanceProvider;
        public IServiceInstanceChecker InstanceChecker;
        public IRegistratedServicesFilter RegistratedServicesFilter;

        public ServiceRegistrar(IServiceInstanceProvider instanceProvider, IServiceInstanceChecker instanceChecker,
            IRegistratedServicesFilter registratedServicesFilter)
        {
            InstanceProvider = instanceProvider;
            InstanceChecker = instanceChecker;
            RegistratedServicesFilter = registratedServicesFilter;
        }

        public void Register(IServiceList list, IEnumerable<IService> services, IReadOnlyContainer container)
        {
            IEnumerable<IService> filteredList = RegistratedServicesFilter.Filter(list, services);

            foreach (IService service in filteredList)
            {
                if (!InstanceChecker.Check(service))
                    InstanceProvider.ProvideInstance(service, container);

                list.AddService(service);
            }
        }
    }
}