using System;

namespace Spencer.NET
{
    public class TypeGetter : ITypeGetter
    {
        public Type GetType<T>()
        {
            return typeof(T);
        }

        public Type GetType(object instance) => instance.GetType();
    }
}