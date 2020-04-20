using System;

namespace Spencer.NET
{
    public interface IContainerChecker
    {
        bool Has<T>();

        bool Has(Type type);
    }
}