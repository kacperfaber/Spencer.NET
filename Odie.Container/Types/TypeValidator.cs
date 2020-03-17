using System;

namespace Odie
{
    public class TypeValidator : ITypeValidator
    {
        public bool Validate(Type type)
        {
            return !type.IsInterface;
        }
    }
}