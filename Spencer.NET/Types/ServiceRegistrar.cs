using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceRegistrar : IServiceRegistrar
    {
        public IRegistratedServicesFilter RegistratedServicesFilter;

        public ServiceRegistrar(IRegistratedServicesFilter registratedServicesFilter)
        {
            RegistratedServicesFilter = registratedServicesFilter;
        }

        public void Register(IServiceList list, IEnumerable<IService> services)
        {
            IEnumerable<IService> filteredList = RegistratedServicesFilter.Filter(list, services);

            foreach (IService service in filteredList)
            {
                list.AddService(service);
            }
        }
    }
}