using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IContainerResolver : IReadOnlyContainerResolver
    {
        T ResolveOrAuto<T>();
        
        object ResolveOrAuto(Type type);

        T ResolveOrDefault<T>();

        object ResolveOrDefault(Type type);
    }
}