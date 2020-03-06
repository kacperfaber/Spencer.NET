using System;

namespace Odie.Reflections
{
    public class ParametersAttribute : Attribute
    {
        public Type ValueType { get; set; }
        
        public object Value { get; set; }

        public ParametersAttribute(object value)
        {
            ValueType = value.GetType();
            Value = value;
        }

        public ParametersAttribute(Type valueType, object value)
        {
            ValueType = valueType;
            Value = value;
        }
    }
}