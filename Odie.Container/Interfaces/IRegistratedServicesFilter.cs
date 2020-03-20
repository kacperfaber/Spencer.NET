using System.Collections.Generic;

namespace Odie
{
    public interface IRegistratedServicesFilter
    {
        IEnumerable<IService> Filter(IServiceList list, IEnumerable<IService> services);
    }
}