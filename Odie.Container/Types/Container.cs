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
        public IServiceGenerator ServiceGenerator;
        public IServiceFinder ServiceFinder;
        public IServiceInitializer ServiceInitializer;
        public ITypeExisterChecker TypeExisterChecker;
        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker;
        public ITypeGetter TypeGetter;
        public IAssemblyRegistrar AssemblyRegistrar;
        public IRegisterParametersGenerator RegisterParametersGenerator;

        public FallbackConfiguration FallbackConfiguration = new FallbackConfiguration();

        public Container(IServiceResolver serviceResolver, IServiceRegistrar serviceRegistrar, IServiceGenerator serviceGenerator, IServiceFinder serviceFinder,
            IServiceInitializer serviceInitializer, ITypeExisterChecker typeExisterChecker, IServiceIsAutoValueChecker serviceIsAutoValueChecker,
            ITypeGetter typeGetter, IAssemblyRegistrar assemblyRegistrar)
        {
            ServiceResolver = serviceResolver;
            ServiceRegistrar = serviceRegistrar;
            ServiceGenerator = serviceGenerator;
            ServiceFinder = serviceFinder;
            ServiceInitializer = serviceInitializer;
            TypeExisterChecker = typeExisterChecker;
            ServiceIsAutoValueChecker = serviceIsAutoValueChecker;
            TypeGetter = typeGetter;
            AssemblyRegistrar = assemblyRegistrar;
            Services = new ServiceList();
            Assemblies = new AssemblyList();
        }

        public IServiceList Services { get; set; }

        public IAssemblyList Assemblies { get; set; }

        public object Resolve(Type type)
        {
            if (!TypeExisterChecker.Check(Services, type))
            {
                FallbackConfiguration.TypeNotRegistered(type, this);
            }

            IService service = ServiceFinder.Find(Services, type);
            object result = ServiceResolver.Resolve(service, this);

            return result;
        }

        public T Resolve<T>()
        {
            Type type = TypeGetter.GetType<T>();

            if (!TypeExisterChecker.Check(Services, type))
            {
                FallbackConfiguration.TypeNotRegistered(type, this);
            }

            IService service = ServiceFinder.Find(Services, type);
            return (T) ServiceResolver.Resolve(service, this);
        }

        public void Register<T>(params object[] parameters)
        {
            Type type = TypeGetter.GetType<T>();
            IRegisterParameters registerParameters = RegisterParametersGenerator.GenerateParameters(parameters);

            IEnumerable<IService> services = ServiceGenerator.GenerateServices(type, Assemblies, null);

            foreach (IService service in services)
            {
                if (ServiceIsAutoValueChecker.Check(service))
                {
                    ServiceInitializer.Initialize(service, this);
                }
            }

            ServiceRegistrar.Register(Services, services, this);
        }

        public IEnumerable<T> ResolveMany<T>()
        {
            Type type = TypeGetter.GetType<T>();

            IEnumerable<IService> services = ServiceFinder.FindMany(Services, type);

            foreach (IService service in services)
            {
                yield return (T) ServiceResolver.Resolve(service, this);
            }
        }

        public IEnumerable<object> ResolveMany(Type type)
        {
            IEnumerable<IService> services = ServiceFinder.FindMany(Services, type);

            foreach (IService service in services)
            {
                yield return ServiceResolver.Resolve(service, this);
            }
        }

        public bool Has<T>()
        {
            Type type = TypeGetter.GetType<T>();

            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);
            return ServiceFinder.Find(Services, type) != null;
        }

        public bool Has(Type type)
        {
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);

            return ServiceFinder.Find(Services, TypeGetter.GetType(type)) != null;
        }

        public void Register(Type type)
        {
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);

            IEnumerable<IService> services = ServiceGenerator.GenerateServices(type, Assemblies, null);

            foreach (IService service in services)
            {
                if (ServiceIsAutoValueChecker.Check(service))
                {
                    ServiceInitializer.Initialize(service, this);
                }
            }

            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterObject(object instance)
        {
            Type type = TypeGetter.GetType(instance);
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);

            IEnumerable<IService> services = ServiceGenerator.GenerateServices(type, Assemblies, null, null, instance);
            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterObject<TKey>(object instance)
        {
            Type type = TypeGetter.GetType();
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);

            IEnumerable<IService> services = ServiceGenerator.GenerateServices(type, Assemblies, null, null, instance);
            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterObject(object instance, Type targetType)
        {
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, targetType);
            IEnumerable<IService> services = ServiceGenerator.GenerateServices(targetType, Assemblies, null, null, instance);
            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterAssembly(Assembly assembly)
        {
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, assembly);

            foreach (Type type in assembly.GetTypes())
            {
                ServiceRegistrar.Register(Services, ServiceGenerator.GenerateServices(type, Assemblies, null), this);
            }
        }

        public void RegisterAssembly<T>()
        {
            Type tType = TypeGetter.GetType<T>();
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, tType);

            foreach (Type type in tType.Assembly.GetTypes())
            {
                ServiceRegistrar.Register(Services, ServiceGenerator.GenerateServices(type, Assemblies, null), this);
            }
        }

        public void RegisterAssemblies(params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                AssemblyRegistrar.RegisterIfNotExist(Assemblies, assembly);

                foreach (Type type in assembly.GetTypes())
                {
                    ServiceRegistrar.Register(Services, ServiceGenerator.GenerateServices(type, Assemblies, null), this);
                }
            }
        }

        public void Register<T>()
        {
            IEnumerable<IService> services = ServiceGenerator.GenerateServices(typeof(T), Assemblies, null);

            foreach (IService service in services)
            {
                if (ServiceIsAutoValueChecker.Check(service))
                {
                    ServiceInitializer.Initialize(service, this);
                }
            }

            ServiceRegistrar.Register(Services, services, this);
        }
    }
}