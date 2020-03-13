using System;

namespace Odie
{
    public interface IContainerRegistrar
    {
        void Register(Type type);

        void Register<T>();
    }
}