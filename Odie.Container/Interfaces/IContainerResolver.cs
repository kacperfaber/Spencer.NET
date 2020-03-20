using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IContainerResolver
    {
        object Resolve(Type type);

        T Resolve<T>();

        T Resolve<T>(params object[] parameters); // TODO not only with generic, but will be with Type

        IEnumerable<T> ResolveMany<T>();

        IEnumerable<object> ResolveMany(Type type);
    }
}