using System;
using System.Reflection;

namespace Odie
{
    public interface IDefaultConstructorProvider
    {
        ConstructorInfo ProvideDefaultConstructor(Type type);
    }
}