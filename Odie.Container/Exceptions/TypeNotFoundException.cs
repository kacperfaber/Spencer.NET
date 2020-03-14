using System;

namespace Odie.Exceptions
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException(Type type) : base($"{type.FullName} was not registered or container cannot get access to it.")
        {
        }
    }
}