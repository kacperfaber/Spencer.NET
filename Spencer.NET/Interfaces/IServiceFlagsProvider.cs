using System;

namespace Spencer.NET
{
    public interface IServiceFlagsProvider
    {
        ServiceFlags ProvideFlags(Type type);
    }
}