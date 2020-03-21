using System;

namespace Odie
{
    public class ConstructorParameter : IConstructorParameter
    {
        public Type Type { get; set; }
        
        public object Value { get; set; }
    }
}