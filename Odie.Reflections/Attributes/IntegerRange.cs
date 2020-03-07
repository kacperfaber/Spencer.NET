using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IntegerRange : ParametersAttribute
    {
        public IntegerRange(int from, int to) : base(new Range(from, to))
        {
        }
    }
}