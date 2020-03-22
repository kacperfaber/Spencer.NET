using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceByInterfaceFinder : IServiceByInterfaceFinder
    {
        public IService FindByInterface(IServiceList list, Type @interface)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.Interfaces.Any())
                .Where(x => x.Registration.Interfaces.SingleOrDefault(y => y.Type.FullName == @interface.FullName) != null)
                .FirstOrDefault();
        }

        public IEnumerable<IService> FindManyByInterface(IServiceList list, Type @interface)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.Interfaces.Any())
                .Where(x => x.Registration.Interfaces.SingleOrDefault(y => y.Type.FullName == @interface.FullName) != null);
        }
    }
}