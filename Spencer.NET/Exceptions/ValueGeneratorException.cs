using System;

namespace Spencer.NET.Exceptions
{
    public class ValueGeneratorException : Exception
    {
        public ValueGeneratorException(Type searchedType) : base($"Container cannot Resolve() type {searchedType.Name}")
        {
        }
    }
}