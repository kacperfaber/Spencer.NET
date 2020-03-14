using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceFinder : IServiceFinder
    {
        public Service Find(ServicesList list, Type typeKey)
        {
            return list
                .GetServices()
                .Where(x => typeKey.IsAssignableFrom(x.Registration.TargetType) || typeKey == x.Registration.TargetType)
                .FirstOrDefault();
        }
    }
}