using System;
using System.Reflection;

namespace Odie
{
    public interface IConstructorProvider
    {
        ConstructorInfo ProvideConstructor(Type type, ServiceFlags flags);
    }
}