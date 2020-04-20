using System;

namespace Spencer.NET
{
    public interface ITypeIsClassValidator
    {
        bool Validate(Type type);
    }
}