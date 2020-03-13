using System;

namespace Odie
{
    public interface IContainerResolver
    {
        object Resolve(Type key);
        
        bool Has(Type key);
    }
}