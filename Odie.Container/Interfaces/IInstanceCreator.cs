using System;

namespace Odie
{
    public interface IInstanceCreator
    {
        object CreateInstance(ServiceFlags flags, Type type, IReadOnlyContainer container);

        object CreateInstance(Type type, IReadOnlyContainer container);

        object CreateInstance(Type type, IConstructorParameters constructorParameter);
    }
}