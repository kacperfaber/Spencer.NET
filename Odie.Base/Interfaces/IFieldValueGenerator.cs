using System;

namespace Odie
{
    public interface IFieldValueGenerator
    {
        object GenerateValue(Property property, out Type outputType);
    }
}