using System;

namespace Spencer.NET
{
    public interface IAutoValueGenerator
    {
        object GenerateValue(Type exceptedType);
    }
}