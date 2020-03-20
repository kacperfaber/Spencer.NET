using System;

namespace Odie
{
    public class ResolveParameter : IResolveParameter
    {
        public Type Type { get; set; }
        public object Value { get; set; }
    }
}