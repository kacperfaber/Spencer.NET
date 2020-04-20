using System;

namespace Spencer.NET
{
    public interface ITypedMemberValueProvider
    {
        object ProvideValue(Type type, IReadOnlyContainer container);
    }
}