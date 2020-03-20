using System;

namespace Odie
{
    public interface IRegisterParameter
    {
        Type Type { get; set; }

        object Value { get; set; }
    }
}