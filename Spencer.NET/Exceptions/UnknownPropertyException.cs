using System;

namespace Spencer.NET
{
    public class UnknownPropertyException : Exception
    {
        public UnknownPropertyException(string property) : base($"Could not specify {property}.")
        {
        }
    }
}