using System;
using System.Reflection;

namespace Odie
{
    public interface IServiceFlagsProvider
    {
        ServiceFlags ProvideFlags(Type type);
    }
}