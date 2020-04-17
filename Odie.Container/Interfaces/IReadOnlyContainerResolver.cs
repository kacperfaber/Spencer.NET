using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IReadOnlyContainerResolver
    {
        object Resolve(Type type);

        T Resolve<T>();
        
        IEnumerable<T> ResolveMany<T>();

        IEnumerable<object> ResolveMany(Type type);
    }
}