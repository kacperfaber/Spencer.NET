using System;
using System.Reflection;

namespace Odie.Exceptions
{
    public class ResolveException : Exception
    {
        public ResolveException(MemberInfo t) : base($"Cannot resolve servive of type {t.Name}")
        {
        }
    }
}