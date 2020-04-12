using System;

namespace Odie
{
    public interface IServiceFactoryProvider
    {
        IServiceFactory ProvideServiceFactory(Type @class, IReadOnlyContainer container);
    }
}