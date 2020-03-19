using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceByInterfaceFinder : IServiceByInterfaceFinder
    {
        public IService FindByInterface(ServicesList list, Type @interface)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.Interfaces.Any())
                .Where(x => x.Registration.Interfaces.SingleOrDefault(y => y == @interface) != null)
                .FirstOrDefault();
        }

        public IEnumerable<IService> FindManyByInterface(ServicesList list, Type @interface)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.Interfaces.Any())
                .Where(x => x.Registration.Interfaces.SingleOrDefault(y => y == @interface) != null);
        }
    }
}