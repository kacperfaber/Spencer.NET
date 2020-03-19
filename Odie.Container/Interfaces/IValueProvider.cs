using System;

namespace Odie
{
    public interface IValueProvider
    {
        object ProvideValue(Type exceptedType, IContainer container);
    }
}