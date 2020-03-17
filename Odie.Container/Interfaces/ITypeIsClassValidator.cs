using System;

namespace Odie
{
    public interface ITypeIsClassValidator
    {
        bool Validate(Type type);
    }
}