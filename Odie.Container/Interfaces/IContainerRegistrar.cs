using System;
using System.Reflection;

namespace Odie
{
    public interface IContainerRegistrar
    {
        void Register(Type type);

        void Register<T>();

        void RegisterObject(object instance);
        
        void RegisterObject<TKey>(object instance);
        
        void RegisterObject(object instance, Type targetType);

        void RegisterAssembly(Assembly assembly);

        void RegisterAssembly<T>();

        void RegisterAssemblies(params Assembly[] assemblies);
    }
}