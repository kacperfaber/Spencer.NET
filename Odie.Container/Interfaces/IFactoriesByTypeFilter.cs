using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IFactoriesByTypeFilter
    {
        IEnumerable<IFactory> Filter(Type targetType, IEnumerable<IFactory> factories);
    }
}