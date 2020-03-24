using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class FactoriesByTypeFilter : IFactoriesByTypeFilter
    {
        public IEnumerable<IFactory> Filter(Type targetType, IEnumerable<IFactory> factories)
        {
            return factories.Where(x => x.ResultType == targetType);
        }
    }
}