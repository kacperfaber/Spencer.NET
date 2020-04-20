using System;

namespace Spencer.NET
{
    public class ConstructorParameter : IConstructorParameter
    {
        public Type Type { get; set; }
        
        public object Value { get; set; }
    }
}