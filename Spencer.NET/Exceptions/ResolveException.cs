using System;
using System.Reflection;

namespace Spencer.NET
{
    public class ResolveException : Exception
    {
        public ResolveException(Type type) : base($"Could not resolve service of type {type.FullName}")
        {
            HelpLink = "https://github.com/kacperfaber/Spencer.NET/blob/v1.1/README.md#exceptions";
        }
    }
}