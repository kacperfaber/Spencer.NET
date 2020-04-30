using System;

namespace Spencer.NET
{
    public interface IInjectValueProvider
    {
        object ProvideValue(Type type, IReadOnlyContainer container);
    }
}