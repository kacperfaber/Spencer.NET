using System.Collections.Generic;

namespace Odie
{
    public interface IServiceList
    {
        void AddService(IService service);

        void AddServices(params IService[] services);

        List<IService> GetServices();
    }
}