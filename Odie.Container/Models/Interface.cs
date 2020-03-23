﻿using System;
using System.Collections.Generic;

namespace Odie
{
    public class Interface : IInterface
    {
        public Type Type { get; set; }
        public bool HasGenericArguments { get; set; }
        public IEnumerable<Type> GenericParameters { get; set; }
    }
}