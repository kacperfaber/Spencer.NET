using System;

namespace Spencer.NET
{
    public interface ITypeIsValueTypeChecker
    {
        bool Check(Type type);
    }
}