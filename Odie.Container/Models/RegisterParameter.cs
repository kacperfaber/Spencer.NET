using System;

namespace Odie
{
    public class RegisterParameter : IRegisterParameter
    {
        public Type Type { get; set; }
        
        public object Value { get; set; }
    }
}