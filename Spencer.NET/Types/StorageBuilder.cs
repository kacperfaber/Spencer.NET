using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class StorageBuilder : Builder<Storage, StorageBuilder>
    {
        public IServicesGenerator ServicesGenerator;
        public IServiceRegistrar ServiceRegistrar;
        public IAssemblyRegistrar AssemblyRegistrar;

        public StorageBuilder Register(Type type)
        {
            return Update(x =>
            {
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Object.Assemblies, null);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public StorageBuilder Register<T>()
        {
            return Update(x =>
            {
                Type type = typeof(T);
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Object.Assemblies, null);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public StorageBuilder Register<T>(params object[] constructorParameters)
        {
            return Update(x =>
            {
                Type type = typeof(T);
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(typeof(T), Object.Assemblies, null);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public StorageBuilder Register(Type type, params object[] constructorParameters)
        {
            return Update(x =>
            {
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Object.Assemblies, null);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public StorageBuilder RegisterAssembly(Assembly assembly)
        {
            return Update(x =>
            {
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, assembly);

                foreach (Type type in assembly.GetTypes())
                {
                    IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, x.Assemblies, null);
                    ServiceRegistrar.Register(x.Services, services);
                }
            });
        }

        public StorageBuilder RegisterAssemblies(params Assembly[] assemblies)
        {
            return Update(x =>
            {
                foreach (var assembly in assemblies)
                {
                    AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, assembly);

                    foreach (Type type in assembly.GetTypes())
                    {
                        IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, x.Assemblies, null);
                        ServiceRegistrar.Register(x.Services, services);
                    }
                }
            });
        }

        public StorageBuilder RegisterAssembly(AssemblyName assemblyName)
        {
            return Update(x =>
            {
                Assembly assembly = Assembly.Load(assemblyName);
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, assembly);

                foreach (Type type in assembly.GetTypes())
                {
                    IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, x.Assemblies, null);
                    ServiceRegistrar.Register(x.Services, services);
                }
            });
        }

        public StorageBuilder RegisterAssemblies(params AssemblyName[] assemblyNames)
        {
            return Update(x =>
            {
                foreach (AssemblyName assemblyName in assemblyNames)
                {
                    Assembly assembly = Assembly.Load(assemblyName);
                    AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, assembly);

                    foreach (Type type in assembly.GetTypes())
                    {
                        IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, x.Assemblies, null);
                        ServiceRegistrar.Register(x.Services, services);
                    }
                }
            });
        }
    }
}