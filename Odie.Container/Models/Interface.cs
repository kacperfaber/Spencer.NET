using System;
using System.Collections.Generic;

namespace Odie
{
    public class Interface : IInterface
    {
        public Type Type { get; set; }
        public bool IsGeneric { get; set; }
        public IEnumerable<Type> GenericParameters { get; set; }
    }
}