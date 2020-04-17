using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IContainerResolver : IReadOnlyContainerResolver
    {
        T ResolveOrDefault<T>();
        
        object ResolveOrDefault(Type type);
    }
}