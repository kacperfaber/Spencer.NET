using System;

namespace Spencer.NET
{
    public interface IServiceFactoryProvider
    {
        IServiceFactory ProvideServiceFactory(Type @class, IReadOnlyContainer container);
        IServiceFactory ProvideServiceFactory(Type @class);
    }
}