using System;

namespace Odie
{
    public interface IServiceFlagsProvider
    {
        ServiceFlags ProvideFlags(Type type);
    }
}