using System;

namespace Spencer.NET
{
    public interface IContainerResolver : IReadOnlyContainerResolver
    {
        T ResolveOrAuto<T>();
        
        object ResolveOrAuto(Type type);
    }
}