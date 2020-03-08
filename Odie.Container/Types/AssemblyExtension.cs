using System;
using System.Reflection;

namespace Odie
{
    public static class AssemblyExtension
    {
        public static void RegisterAssemblyTypes(this ServiceLoader loader, Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                loader.RegisterInterfaces(type);
                loader.RegisterType(type);
            }
        }

        
    }
}