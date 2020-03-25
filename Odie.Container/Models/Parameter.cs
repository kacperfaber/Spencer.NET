using System;

namespace Odie
{
    public class Parameter : IParameter
    {
        public Type Type { get; set; }

        public object Value { get; set; }
        
        public bool HasDefaultValue { get; set; }
        
        public object DefaultValue { get; set; }
    }
}