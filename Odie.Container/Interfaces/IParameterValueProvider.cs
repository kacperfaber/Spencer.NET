using System;

namespace Odie
{
    public interface IParameterValueProvider
    {
        object ProvideValue(ITypedMember member, IContainer container);
    }
}