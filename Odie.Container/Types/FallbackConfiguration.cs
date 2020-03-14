using System;
using Odie.Exceptions;

namespace Odie
{
    public class FallbackConfiguration
    {
        public virtual void TypeNotRegistered(Type type, IContainer container)
        {
            throw new TypeNotFoundException(type);
        }
    }
}