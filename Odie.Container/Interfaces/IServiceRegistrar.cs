using System.Collections.Generic;

namespace Odie
{
    public interface IServiceRegistrar
    {
        void Register(IServiceList list, IEnumerable<IService> services, IReadOnlyContainer container);
        
        // TODO Register(.., IService) AND Register(.., IEnummerable>
    }
}