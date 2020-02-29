using System;

namespace Odie.Engine
{
    public class FieldGenerator : IFieldGenerator
    {
        public Field Generate(Property property)
        {
            return new Field()
            {
                Name = GenerateName(property),
                Type = GenerateType(property),
                Value = GenerateValue(property)
            };
        }

        public object GenerateValue(Property property)
        {
            return null;
        }

        public string GenerateName(Property property)
        {
            return property.Name;
        }

        public Type GenerateType(Property property)
        {
            return property.ExceptedType;
        }
    }
}