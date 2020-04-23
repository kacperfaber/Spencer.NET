using System;

namespace Spencer.NET
{
    public class AutoException : Exception
    {
        public AutoException(Type type) : base($"Cannot generate Auto value for type {type.FullName}")
        {
        }
    }
}