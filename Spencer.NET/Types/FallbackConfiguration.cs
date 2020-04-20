using System;
using Spencer.NET.Exceptions;

namespace Spencer.NET
{
    public class FallbackConfiguration
    {
        public virtual void TypeNotRegistered(Type type, IContainer container)
        {
            throw new TypeNotFoundException(type);
        }
    }
}