using System.Collections.Generic;

namespace Spencer.NET
{
    public class ServiceList : List<IService>, IServiceList
    {
        public ServiceList() : base()
        {
        }

        public void AddService(IService service)
        {
            Add(service);
        }

        public void AddServices(params IService[] services)
        {
            foreach (IService service in services)
            {
                Add(service);
            }
        }

        public List<IService> GetServices() => this;
    }
}