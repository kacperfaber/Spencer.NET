using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IFactoriesByTypeFilter
    {
        IEnumerable<IFactory> Filter(Type targetType, IEnumerable<IFactory> factories);
    }
}