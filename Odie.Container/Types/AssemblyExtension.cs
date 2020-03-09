using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            
            loader.Assemblies.Add(assembly);
        }

        public static void RegisterAssemblies(this ServiceLoader loader, Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                loader.RegisterAssemblyTypes(assembly);
            }
        }
        
        public static void RegisterAssemblies(this ServiceLoader loader, AssemblyName[] assemblyNames)
        {
            foreach (AssemblyName assembly in assemblyNames)
            {
                loader.RegisterAssemblyTypes(Assembly.Load(assembly));
            }
        }

        public static void RegisterAssembly(this ServiceLoader loader, Assembly assembly)
        {
            loader.RegisterAssemblyTypes(assembly);
            loader.RegisterAssemblies(assembly.GetReferencedAssemblies());
        }

        public static void ScanAssembly(this ServiceLoader loader, params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> delegates = assembly.GetTypes()
                    .Where(x => x.GetInterfaces().Contains(typeof(IContainerDelegate)))
                    .Where(x => Attribute.GetCustomAttributes(x, typeof(ContainerDelegateAttribute)).Any());

                foreach (Type @delegate in delegates)
                {
                    object delegateInstance = Activator.CreateInstance(@delegate);

                    MethodInfo registerMethod = @delegate.GetMethod("Register");
                    
                    registerMethod.Invoke(delegateInstance, new object[] {loader});
                }
            }
        }
    }
}