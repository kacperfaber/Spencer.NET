using System;

namespace Odie
{
    public interface IConstructorProvider
    {
        IConstructor ProvideConstructor(IService service);

        IConstructor ProvideConstructor(Type type);
    }
}