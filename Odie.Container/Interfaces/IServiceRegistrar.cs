using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrar
    {
        void Register(ServicesList list, Service service, IContainer container);
    }
}