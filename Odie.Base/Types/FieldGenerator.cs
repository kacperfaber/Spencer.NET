using System;
using System.Linq;

namespace Odie
{
    public class FieldGenerator : IFieldGenerator
    {
        public FieldBuilder Builder;

        public FieldGenerator(FieldBuilder builder)
        {
            Builder = builder;
        }

        public Field Generate(Property property)
        {
            Builder.Clear();

            object value = property.ValueGenerator.Generate(property.Parameters, property.ParametersType.First(), new[] {property.ExceptedType},
                out Type outputType);

            return Builder
                .AddName(property.Name)
                .AddValue(value)
                .AddType(outputType)
                .Build();
        }
    }
}