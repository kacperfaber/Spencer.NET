using System.Collections.Generic;

namespace Spencer.NET
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

        public void Register(IServiceList list, IEnumerable<IService> services)
        {
            IEnumerable<IService> filteredList = RegistratedServicesFilter.Filter(list, services);

            foreach (IService service in filteredList)
            {
                if (!InstanceChecker.Check(service))
                    InstanceProvider.ProvideInstance(service);

                list.AddService(service);
            }
        }
    }
}