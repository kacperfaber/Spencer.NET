using System;
using System.Reflection;

namespace Odie
{
    public interface IConstructorProvider
    {
        IConstructor ProvideConstructor(Type type, ServiceFlags flags);

        IConstructor ProvideConstructor(Type type);
    }
}