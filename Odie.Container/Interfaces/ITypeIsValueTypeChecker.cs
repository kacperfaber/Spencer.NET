using System;

namespace Odie
{
    public interface ITypeIsValueTypeChecker
    {
        bool Check(Type type);
    }
}