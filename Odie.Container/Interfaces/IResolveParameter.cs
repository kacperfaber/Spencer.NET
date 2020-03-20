using System;

namespace Odie
{
    public interface IResolveParameter
    {
        Type Type { get; set; }

        object Value { get; set; }
    }
}