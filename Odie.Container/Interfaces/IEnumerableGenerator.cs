using System;

namespace Odie
{
    public interface IEnumerableGenerator
    {
        object GenerateEnumerable(Type enumerableType);
    }
}