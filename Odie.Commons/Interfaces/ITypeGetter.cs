using System;

namespace Odie
{
    public interface ITypeGetter
    {
        Type GetType(object instance);

        Type GetType<T>();
    }
}