using System;
using System.Reflection;

namespace Odie
{
    public interface IConstructorProvider
    {
        IConstructor ProvideConstructor(IService service);

        IConstructor ProvideConstructor(Type type);
    }
}