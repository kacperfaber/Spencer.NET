using System;
using System.Collections.Generic;

namespace Odie
{
    public class Property
    {
        public string Name { get; set; }
        
        public Flags Flags { get; set; }
        
        public Type ExceptedType { get; set; }

        public IValueGenerator ValueGenerator { get; set; }
        
        public Type ValueGeneratorType { get; set; }

        public List<object> Parameters { get; set; }

        public List<Type> ParametersType { get; set; }

        public Property()
        {
            Parameters = new List<object>();
            ParametersType = new List<Type>();
        }
    }
}