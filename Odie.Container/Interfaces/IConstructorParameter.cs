using System;

namespace Odie
{
    public interface IConstructorParameter
    {
        Type Type { get; set; }

        object Value { get; set; }
    }
}