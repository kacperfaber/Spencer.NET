using System;

namespace Odie
{
    public class TypeIsClassValidator : ITypeIsClassValidator
    {
        public bool Validate(Type type)
        {
            return !type.IsInterface;
        }
    }
}