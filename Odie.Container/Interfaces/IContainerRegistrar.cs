using System;

namespace Odie
{
    public interface IContainerRegistrar
    {
        void Register(Type type);

        void Register<T>();

        void RegisterObject(object instance);
        
        void RegisterObject<TKey>(object instance);
        
        void RegisterObject(object instance, Type targetType);
    }
}