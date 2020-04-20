using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class RegistratedServicesFilter : IRegistratedServicesFilter
    {
        public IEnumerable<IService> Filter(IServiceList list, IEnumerable<IService> services)
        {
            return services.Where(x => list.GetServices().SingleOrDefault(y => y.Registration.TargetType == x.Registration.TargetType) == null);
        }
    }
}