using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrar
    {
        void Register(ref IEnumerable<Service> services, Service service, IContainerResolver resolver, IContainerRegistrar registrar);
    }
}