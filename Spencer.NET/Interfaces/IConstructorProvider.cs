using System;

namespace Spencer.NET
{
    public interface IConstructorProvider
    {
        IConstructor ProvideConstructor(IService service);

        IConstructor ProvideConstructor(Type type);
    }
}