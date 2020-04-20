using System;

namespace Spencer.NET
{
    public interface IEnumerableGenerator
    {
        object GenerateEnumerable(Type enumerableType);
    }
}