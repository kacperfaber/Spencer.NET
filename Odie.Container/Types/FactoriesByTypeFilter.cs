using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class FactoriesByTypeFilter : IFactoriesByTypeFilter
    {
        public IAssignableChecker AssignableChecker;

        public FactoriesByTypeFilter(IAssignableChecker assignableChecker)
        {
            AssignableChecker = assignableChecker;
        }

        public IEnumerable<IFactory> Filter(Type targetType, IEnumerable<IFactory> factories)
        {
            return factories.Where(x => AssignableChecker.Check(x.ResultType, targetType));
        }
    }
}