using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ServiceByClassFinder : IServiceByClassFinder
    {
        public IService FindByClass(IServiceList list, Type @class)
        {
            IEnumerable<IService> assignable = list.GetServices()
                .Where(x => @class.IsAssignableFrom(x.Registration.TargetType) || x.Registration.RegistrationFlags
                    .Where(x => x.Code == RegistrationFlagConstants.AsClass).Any(x => x.Value as Type == @class));

            return assignable.FirstOrDefault();
        }

        public IEnumerable<IService> FindManyByClass(IServiceList list, Type @class)
        {
            IEnumerable<IService> assignable = list.GetServices()
                .Where(x => @class.IsAssignableFrom(x.Registration.TargetType) || x.Registration.RegistrationFlags
                    .Where(x => x.Code == RegistrationFlagConstants.AsClass).Any(x => x.Value as Type == @class));

            return assignable;
        }
    }
}