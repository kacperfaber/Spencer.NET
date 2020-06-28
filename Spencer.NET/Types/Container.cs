using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public sealed class Container : ReadOnlyContainer, IContainer
    {
        public IServiceInitializer ServiceInitializer;
        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker;
        public IConstructorParametersByObjectsGenerator ConstructorParametersByObjectsGenerator;

        public Container(IStorage storage, IServiceRegistrar serviceRegistrar, IServicesGenerator servicesGenerator, IServiceFinder serviceFinder,
            IServiceInitializer serviceInitializer, IServiceIsAutoValueChecker serviceIsAutoValueChecker,
            ITypeGetter typeGetter, IAssemblyRegistrar assemblyRegistrar, IConstructorParametersByObjectsGenerator constructorParametersByObjectsGenerator,
            IServiceInstanceResolver serviceInstanceResolver) : base(storage, serviceFinder, typeGetter, serviceInstanceResolver, assemblyRegistrar, serviceRegistrar, servicesGenerator)
        {
            ServicesGenerator = servicesGenerator;
            ServiceFinder = serviceFinder;
            ServiceInitializer = serviceInitializer;
            ServiceIsAutoValueChecker = serviceIsAutoValueChecker;
            ConstructorParametersByObjectsGenerator = constructorParametersByObjectsGenerator;
            TypeGetter = typeGetter;
            AssemblyRegistrar = assemblyRegistrar;
            ServiceInstanceResolver = serviceInstanceResolver;
        }

        public void Register(Type type)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);

            IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, null);

            foreach (IService service in services)
            {
                if (ServiceIsAutoValueChecker.Check(service))
                {
                    ServiceInitializer.Initialize(service, this);
                }
            }

            ServiceRegistrar.Register(Storage.Services, services);
        }

        public void RegisterObject(object instance)
        {
            Type type = TypeGetter.GetType(instance);
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);

            IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, null, null, instance);
            ServiceRegistrar.Register(Storage.Services, services);
        }

        public void RegisterObject<TKey>(object instance)
        {
            Type type = TypeGetter.GetType(instance);
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);

            IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, null, null, instance);
            ServiceRegistrar.Register(Storage.Services, services);
        }

        public void RegisterObject(object instance, Type targetType)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, targetType);
            IEnumerable<IService> services = ServicesGenerator.GenerateServices(targetType, Storage.Assemblies, null, null, instance);
            ServiceRegistrar.Register(Storage.Services, services);
        }

        public void RegisterAssembly(Assembly assembly)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, assembly);

            foreach (Type type in assembly.GetTypes())
            {
                ServiceRegistrar.Register(Storage.Services, ServicesGenerator.GenerateServices(type, Storage.Assemblies, null));
            }
        }

        public void RegisterAssembly<T>()
        {
            Type tType = TypeGetter.GetType<T>();
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, tType);

            foreach (Type type in tType.Assembly.GetTypes())
            {
                ServiceRegistrar.Register(Storage.Services, ServicesGenerator.GenerateServices(type, Storage.Assemblies, null));
            }
        }

        public void RegisterAssemblies(params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, assembly);

                foreach (Type type in assembly.GetTypes())
                {
                    ServiceRegistrar.Register(Storage.Services, ServicesGenerator.GenerateServices(type, Storage.Assemblies, null));
                }
            }
        }

        public void Register<T>(params object[] parameters)
        {
            Type type = TypeGetter.GetType<T>();
            IConstructorParameters constructorParameters = ConstructorParametersByObjectsGenerator.GenerateParameters(parameters);

            IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, this, constructorParameters);

            foreach (IService service in services)
            {
                if (ServiceIsAutoValueChecker.Check(service))
                {
                    ServiceInitializer.Initialize(service, this);
                }
            }

            ServiceRegistrar.Register(Storage.Services, services);
        }

        public void Register<T>()
        {
            IEnumerable<IService> services = ServicesGenerator.GenerateServices(typeof(T), Storage.Assemblies, null);

            foreach (IService service in services)
            {
                if (ServiceIsAutoValueChecker.Check(service))
                {
                    ServiceInitializer.Initialize(service, this);
                }
            }

            ServiceRegistrar.Register(Storage.Services, services);
        }

        public T ResolveOrAuto<T>()
        {
            Type type = TypeGetter.GetType<T>();
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);
            IService service = ServiceFinder.Find(Storage.Services, type);

            if (service == null)
            {
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, this);

                ServiceRegistrar.Register(Storage.Services, services);

                return (T) ServiceInstanceResolver.ResolveInstance(ServiceFinder.Find(Storage.Services, type), this);
            }
            
            return (T) ServiceInstanceResolver.ResolveInstance(service, this);
        }

        public object ResolveOrAuto(Type type)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);
            IService service = ServiceFinder.Find(Storage.Services, type);

            if (service == null)
            {
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, this);

                ServiceRegistrar.Register(Storage.Services, services);

                return ServiceInstanceResolver.ResolveInstance(ServiceFinder.Find(Storage.Services, type), this);
            }
            
            return ServiceInstanceResolver.ResolveInstance(service, this);
        }
    }
}