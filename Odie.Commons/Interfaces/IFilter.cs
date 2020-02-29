using System.Collections.Generic;

namespace Odie.Commons
{
    public interface IFilter <T>
    {
        IEnumerable<T> Filter(IEnumerable<T> enumerable);
    }
}