using System;
using System.Reflection;

namespace Spencer.NET
{
    public class ContainerBuilder
    {
        public void RegisterClass<T>() where T : class
        {
        }

        public void RegisterInterface<T>()
        {
        }

        public void RegisterAssembly(Assembly assembly)
        {
        }

        public void Register(Type type)
        {
        }

        public void Register<T>()
        {
        }
    }
}