using System.Collections.Generic;

namespace Odie
{
    public class ServicesList
    {
        public List<IService> Services { get; set; }

        public ServicesList()
        {
            Services = new List<IService>();
        }

        public void AddService(IService service)
        {
            Services.Add(service);
        }

        public List<IService> GetServices() => Services;
    }
}