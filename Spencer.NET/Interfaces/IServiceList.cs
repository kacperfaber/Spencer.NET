using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceList
    {
        void AddService(IService service);

        void AddServices(params IService[] services);

        List<IService> GetServices();
    }
}