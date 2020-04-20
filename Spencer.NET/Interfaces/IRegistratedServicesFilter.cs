using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IRegistratedServicesFilter
    {
        IEnumerable<IService> Filter(IServiceList list, IEnumerable<IService> services);
    }
}