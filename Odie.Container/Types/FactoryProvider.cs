using System;
using System.Collections.Generic;

namespace Odie
{
    public class FactoryProvider : IFactoryProvider
    {
        public IFactoriesProvider FactoriesProvider;
        public IFactoriesByTypeFilter ByTypeFilter;
        
        public IFactory ProvideFactory(IService service)
        {
            IEnumerable<IFactory> factories = FactoriesProvider.ProvideFactories(service);
            IEnumerable<IFactory> byTypeFiltered = ByTypeFilter.Filter(service.Registration.TargetType, factories); // TODO can check ResultType in attr and returntype.. :D

            throw new NotImplementedException();
        }
    }
}