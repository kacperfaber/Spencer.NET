using System;
using System.Linq;

namespace Odie
{
    public class FieldValueGenerator : IFieldValueGenerator
    {
        public object GenerateValue(Property property, out Type outputType)
        {
            return property.ValueGenerator.Generate(property.Parameters, property.ParametersType.First(), new[] {property.ExceptedType},
                out outputType);
        }
    }
}