using System;

namespace Odie.Commons
{
    public interface ITypeGetter
    {
        Type GetType(object instance);

        Type GetType<T>();
    }
}