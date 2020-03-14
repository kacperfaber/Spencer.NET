using System;

namespace Odie
{
    public interface IInstanceCreator
    {
        object CreateInstance(ServiceFlags flags, Type type, IContainer container);
    }
}