using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IFactoriesByModifiersFilter
    {
        IEnumerable<IFactory> Filter(IEnumerable<IFactory> factories);
    }
}