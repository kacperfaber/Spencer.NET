using System;

namespace Odie
{
    public interface IContainerResolver
    {
        object Resolve(Type key);

        T Resolve<T>();
        
        // TODO Resolve with action filter like Func<Type[], Type>
    }
}