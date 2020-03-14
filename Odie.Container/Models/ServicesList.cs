using System.Collections.Generic;

namespace Odie
{
    public class ServicesList
    {
        public List<Service> Services { get; set; }

        public ServicesList()
        {
            Services = new List<Service>();
        }

        public void AddService(Service service)
        {
            Services.Add(service);
        }

        public List<Service> GetServices() => Services;
    }
}