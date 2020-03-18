using System.Collections.Generic;

namespace Odie
{
    public interface IFilter <T>
    {
        IEnumerable<T> Filter(IEnumerable<T> enumerable);
    }
}