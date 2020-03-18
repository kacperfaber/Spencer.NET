using System;

namespace Odie
{
    public class TypeChangerValidator : ITypeChangerValidator
    {
        public bool CanChange(Type @from, Type to)
        {
            return @to.IsAssignableFrom(@from);
        }

        public bool CanChange<TFrom, TTo>()
        {
            return typeof(TTo).IsAssignableFrom(typeof(TFrom));
        }
    }
}