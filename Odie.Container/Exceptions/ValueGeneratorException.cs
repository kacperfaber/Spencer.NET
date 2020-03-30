using System;

namespace Odie.Exceptions
{
    public class ValueGeneratorException : Exception
    {
        public ValueGeneratorException(Type searchedType) : base($"Container cannot Resolve() type {nameof(searchedType)}")
        {
        }
    }
}