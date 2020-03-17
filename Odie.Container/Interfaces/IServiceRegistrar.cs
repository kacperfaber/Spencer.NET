using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrar
    {
        void Register(ServicesList list, IEnumerable<Service> services, IContainer container);
    }
}