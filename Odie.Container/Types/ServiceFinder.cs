using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceFinder : IServiceFinder
    {
        public Service Find(IEnumerable<Service> services, Type typeKey)
        {
            return services
                .Where(x => typeKey.IsAssignableFrom(x.Registration.TargetType))
                .FirstOrDefault();
        }
    }
}