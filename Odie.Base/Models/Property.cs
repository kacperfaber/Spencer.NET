﻿using System;

namespace Odie
{
    public class Property
    {
        public string Name { get; set; }
        
        public Flags Flags { get; set; }
        
        public Type ExceptedType { get; set; }

        public IValueGenerator ValueGenerator { get; set; }
        
        public Type ValueGeneratorType { get; set; }

        public object[] Parameters { get; set; }

        public Type[] ParametersType { get; set; }
    }
}