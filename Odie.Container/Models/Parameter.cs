using System;

namespace Odie
{
    public class Parameter : IParameter
    {
        public Type ParameterType { get; set; }
        
        public object Value { get; set; }
    }
}