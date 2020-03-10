using System;

namespace Odie
{
    public interface IValueGenerator
    {
        object Generate(object parameters, Type parametersType, Type[] exceptedType, out Type valueType);
    }
}