using System;

namespace Odie.Commons
{
    public class TypeGetter : ITypeGetter
    {
        public Type GetType(object instance)
        {
            return instance.GetType();
        }

        public Type GetType<T>()
        {
            return typeof(T);
        }
    }
}