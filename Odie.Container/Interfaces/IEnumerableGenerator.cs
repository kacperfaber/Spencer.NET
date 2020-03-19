using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IEnumerableGenerator
    {
        object GenerateEnumerable(Type enumerableType);
    }
}