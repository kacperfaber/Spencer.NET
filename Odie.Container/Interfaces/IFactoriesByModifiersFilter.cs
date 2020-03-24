using System.Collections.Generic;

namespace Odie
{
    public interface IFactoriesByModifiersFilter
    {
        IEnumerable<IFactory> Filter(IEnumerable<IFactory> factories);
    }
}