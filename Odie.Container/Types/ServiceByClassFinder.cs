using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceByClassFinder : IServiceByClassFinder
    {
        public IService FindByClass(ServicesList list, Type @class)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.TargetType.IsAssignableFrom(@class))
                .FirstOrDefault();
        }

        public IEnumerable<IService> FindManyByClass(ServicesList list, Type @class)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.TargetType.IsAssignableFrom(@class));
        }
    }
}