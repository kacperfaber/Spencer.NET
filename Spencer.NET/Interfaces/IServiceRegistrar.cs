using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServiceRegistrar
    {
        void Register(IServiceList list, IEnumerable<IService> services);
        
        // TODO Register(.., IService) AND Register(.., IEnummerable>
    }
}