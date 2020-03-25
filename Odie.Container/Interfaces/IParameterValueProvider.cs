using System;

namespace Odie
{
    public interface IParameterValueProvider
    {
        object ProvideValue(IParameter parameter, IContainer container);
    }
}