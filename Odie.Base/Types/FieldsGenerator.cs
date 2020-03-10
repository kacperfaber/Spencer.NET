using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class FieldsGenerator : IFieldsGenerator
    {
        public IFieldGenerator FieldGenerator;

        public FieldsGenerator(IFieldGenerator fieldGenerator)
        {
            FieldGenerator = fieldGenerator;
        }

        public IEnumerable<Field> Generate(IEnumerable<Property> properties)
        {
            foreach (Property property in properties)
            {
                yield return FieldGenerator.Generate(property);
            }
        }
    }
}