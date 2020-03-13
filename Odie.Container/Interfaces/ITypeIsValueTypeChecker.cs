using System;
using System.Reflection;

namespace Odie
{
    public interface ITypeIsValueTypeChecker
    {
        bool Check(Type type);
    }
}