using System;
using System.Reflection;

namespace Spencer.NET
{
    public class ResolveException : Exception
    {
        public ResolveException(MemberInfo t) : base($"Cannot resolve servive of type {t.Name}")
        {
        }
    }
}