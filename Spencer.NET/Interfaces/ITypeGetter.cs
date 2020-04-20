using System;

namespace Spencer.NET
{
    public interface ITypeGetter
    {
        Type GetType<T>();

        Type GetType(object instance);
    }
}