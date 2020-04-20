using System;
using System.Reflection;

namespace Spencer.NET
{
    public interface IDefaultConstructorProvider
    {
        ConstructorInfo ProvideDefaultConstructor(Type type);
    }
}