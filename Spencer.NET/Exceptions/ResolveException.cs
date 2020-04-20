using System;
using System.Reflection;

namespace Spencer.NET.Exceptions
{
    public class ResolveException : Exception
    {
        public ResolveException(MemberInfo t) : base($"Cannot resolve servive of type {t.Name}")
        {
        }
    }
}