using System;

namespace Odie
{
    public interface ITypeChangerValidator
    {
        bool CanChange(Type from, Type to);

        bool CanChange<TFrom, TTo>();
    }
}