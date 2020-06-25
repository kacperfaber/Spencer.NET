using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ServiceByClassFinder : IServiceByClassFinder
    {
        public IService FindByClass(IServiceList list, Type @class)
        {
            return list
                .GetServices()
                .Where(x => (x.Registration.RegistrationFlags.SingleOrDefault(x => x.Code == RegistrationFlagConstants.AsClass).Value as Type) == @class)
                // .Where(x => x.Registration.TargetType.IsAssignableFrom(@class))
                .FirstOrDefault();
        }

        public IEnumerable<IService> FindManyByClass(IServiceList list, Type @class)
        {
            return list
                .GetServices()
                .Where(x => x.Registration.TargetType.IsAssignableFrom(@class));
        }
    }
}