using System;

namespace Odie.Commons
{
    public interface ITypeChangerValidator
    {
        bool CanChange(Type from, Type to);

        bool CanChange<TFrom, TTo>();
    }
}