using System;

namespace Spencer.NET
{
    public interface IContainerResolver : IReadOnlyContainerResolver
    {
        T ResolveOrAuto<T>();
        
        object ResolveOrAuto(Type type);

        T ResolveOrDefault<T>();

        object ResolveOrDefault(Type type);
    }
}