using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrar
    {
        void Register(ServicesList list, IEnumerable<IService> services, IContainer container);
    }
}