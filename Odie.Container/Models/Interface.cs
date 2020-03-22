using System;

namespace Odie
{
    public class Interface : IInterface
    {
        public Type Type { get; set; }
        public bool IsGeneric { get; set; }
        public Type[] GenericParameters { get; set; }
    }
}