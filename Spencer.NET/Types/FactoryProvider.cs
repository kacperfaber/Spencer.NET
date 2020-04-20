using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class FactoryProvider : IFactoryProvider
    {
        public IFactoriesProvider FactoriesProvider;
        public IFactoriesByTypeFilter ByTypeFilter;

        public FactoryProvider(IFactoriesByTypeFilter byTypeFilter, IFactoriesProvider factoriesProvider)
        {
            ByTypeFilter = byTypeFilter;
            FactoriesProvider = factoriesProvider;
        }

        public IFactory ProvideFactory(IService service)
        {
            IEnumerable<IFactory> factories = FactoriesProvider.ProvideFactories(service);
            IEnumerable<IFactory> byTypeFiltered = ByTypeFilter.Filter(service.Registration.TargetType, factories);
            IEnumerable<IFactory> orderedByMethodFirsts = byTypeFiltered.OrderBy(x => x.Type == FactoryType.StaticMethod).AsEnumerable();

            return orderedByMethodFirsts.First();
        }
    }
}