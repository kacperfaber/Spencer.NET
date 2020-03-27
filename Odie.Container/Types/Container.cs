using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class Container : IContainer
    {
        public IServiceResolver ServiceResolver;
        public IServiceRegistrar ServiceRegistrar;
        public IServicesGenerator ServicesGenerator;
        public IServiceFinder ServiceFinder;
        public IServiceInitializer ServiceInitializer;
        public ITypeExisterChecker TypeExisterChecker;
        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker;
        public ITypeGetter TypeGetter;
        public IAssemblyRegistrar AssemblyRegistrar;
        public IConstructorParametersByObjectsGenerator ConstructorParametersByObjectsGenerator;

        public FallbackConfiguration FallbackConfiguration = new FallbackConfiguration();

        public Container(IServiceResolver serviceResolver, IServiceRegistrar serviceRegistrar, IServicesGenerator servicesGenerator, IServiceFinder serviceFinder,
            IServiceInitializer serviceInitializer, ITypeExisterChecker typeExisterChecker, IServiceIsAutoValueChecker serviceIsAutoValueChecker,
            ITypeGetter typeGetter, IAssemblyRegistrar assemblyRegistrar, IConstructorParametersByObjectsGenerator constructorParametersByObjectsGenerator)
        {
            ServiceResolver = serviceResolver;
            ServiceRegistrar = serviceRegistrar;
            ServicesGenerator = servicesGenerator;
            ServiceFinder = serviceFinder;
            ServiceInitializer = serviceInitializer;
            TypeExisterChecker = typeExisterChecker;
            ServiceIsAutoValueChecker = serviceIsAutoValueChecker;
            TypeGetter = typeGetter;
            AssemblyRegistrar = assemblyRegistrar;
            ConstructorParametersByObjectsGenerator = constructorParametersByObjectsGenerator;
            
            Storage = new Storage();
        }
        
        public IStorage Storage { get; set; }

        public object Resolve(Type type)
        {
            if (!TypeExisterChecker.Check(Storage.Services, type))
            {
                FallbackConfiguration.TypeNotRegistered(type, this);
            }

            IService service = ServiceFinder.Find(Storage.Services, type);
            object result = ServiceResolver.Resolve(service, this);

            return result;
        }

        public T Resolve<T>()
        {
            Type type = TypeGetter.GetType<T>();

            if (!TypeExisterChecker.Check(Storage.Services, type))
            {
                FallbackConfiguration.TypeNotRegistered(type, this);
            }

            IService service = ServiceFinder.Find(Storage.Services, type);
            return (T) ServiceResolver.Resolve(service, this);
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

            ServiceRegistrar.Register(Storage.Services, services, this);
        }

        public IEnumerable<T> ResolveMany<T>()
        {
            Type type = TypeGetter.GetType<T>();

            IEnumerable<IService> services = ServiceFinder.FindMany(Storage.Services, type);

            foreach (IService service in services)
            {
                yield return (T) ServiceResolver.Resolve(service, this);
            }
        }

        public IEnumerable<object> ResolveMany(Type type)
        {
            IEnumerable<IService> services = ServiceFinder.FindMany(Storage.Services, type);

            foreach (IService service in services)
            {
                yield return ServiceResolver.Resolve(service, this);
            }
        }

        public bool Has<T>()
        {
            Type type = TypeGetter.GetType<T>();

            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);
            return ServiceFinder.Find(Storage.Services, type) != null;
        }

        public bool Has(Type type)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);

            return ServiceFinder.Find(Storage.Services, TypeGetter.GetType(type)) != null;
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

            ServiceRegistrar.Register(Storage.Services, services, this);
        }

        public void RegisterObject(object instance)
        {
            Type type = TypeGetter.GetType(instance);
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);

            IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, null, null, instance);
            ServiceRegistrar.Register(Storage.Services, services, this);
        }

        public void RegisterObject<TKey>(object instance)
        {
            Type type = TypeGetter.GetType();
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, type);

            IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Storage.Assemblies, null, null, instance);
            ServiceRegistrar.Register(Storage.Services, services, this);
        }

        public void RegisterObject(object instance, Type targetType)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, targetType);
            IEnumerable<IService> services = ServicesGenerator.GenerateServices(targetType, Storage.Assemblies, null, null, instance);
            ServiceRegistrar.Register(Storage.Services, services, this);
        }

        public void RegisterAssembly(Assembly assembly)
        {
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, assembly);

            foreach (Type type in assembly.GetTypes())
            {
                ServiceRegistrar.Register(Storage.Services, ServicesGenerator.GenerateServices(type, Storage.Assemblies, null), this);
            }
        }

        public void RegisterAssembly<T>()
        {
            Type tType = TypeGetter.GetType<T>();
            AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, tType);

            foreach (Type type in tType.Assembly.GetTypes())
            {
                ServiceRegistrar.Register(Storage.Services, ServicesGenerator.GenerateServices(type, Storage.Assemblies, null), this);
            }
        }

        public void RegisterAssemblies(params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                AssemblyRegistrar.RegisterIfNotExist(Storage.Assemblies, assembly);

                foreach (Type type in assembly.GetTypes())
                {
                    ServiceRegistrar.Register(Storage.Services, ServicesGenerator.GenerateServices(type, Storage.Assemblies, null), this);
                }
            }
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

            ServiceRegistrar.Register(Storage.Services, services, this);
        }

        
    }
}