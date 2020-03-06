using System.Collections.Generic;

namespace Odie.Commons
{
    public interface IArrayTypeChanger
    {
        IEnumerable<T> ChangeType<T>(IEnumerable<object> enumerable);

        T[] ChangeType<T>(object[] array);
    }
}