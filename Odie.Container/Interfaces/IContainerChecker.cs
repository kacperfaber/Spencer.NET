using System;

namespace Odie
{
    public interface IContainerChecker
    {
        bool Has<T>();

        bool Has(Type type);
    }
}