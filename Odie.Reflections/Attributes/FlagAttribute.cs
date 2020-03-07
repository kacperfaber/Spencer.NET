using System;

namespace Odie
{
    public class FlagAttribute : Attribute
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public FlagAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}