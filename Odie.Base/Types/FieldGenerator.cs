using System;
using System.Linq;

namespace Odie
{
    public class FieldGenerator : IFieldGenerator
    {
        public FieldBuilder Builder;
        public IFieldValueGenerator ValueGenerator;

        public FieldGenerator(FieldBuilder builder, IFieldValueGenerator valueGenerator)
        {
            Builder = builder;
            ValueGenerator = valueGenerator;
        }

        public Field Generate(Property property)
        {
            Builder.Clear();

            object value = ValueGenerator.GenerateValue(property, out Type outputType);

            return Builder
                .AddName(property.Name)
                .AddValue(value)
                .AddType(outputType)
                .Build();
        }
    }
}