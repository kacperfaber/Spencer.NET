using System;

namespace Spencer.NET
{
    public class TypeIsClassValidator : ITypeIsClassValidator
    {
        public bool Validate(Type type)
        {
            return !type.IsInterface;
        }
    }
}