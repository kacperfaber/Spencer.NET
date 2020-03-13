using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrar
    {
        void Register(IEnumerable<Service> services, Service service);
    }
}