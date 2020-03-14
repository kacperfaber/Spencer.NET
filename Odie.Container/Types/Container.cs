using System;
using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class Container : IContainer
    {
        public ServicesList Services = new ServicesList();

        public IServiceResolver ServiceResolver;
        public IServiceRegistrar ServiceRegistrar;
        public IServiceGenerator ServiceGenerator;
        public IServiceFinder ServiceFinder;
        public IServiceInitializer ServiceInitializer;
        public ITypeExisterChecker TypeExisterChecker;
        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker;
        public ITypeGetter TypeGetter;
        
        public FallbackConfiguration FallbackConfiguration = new FallbackConfiguration();

        public Container(IServiceResolver serviceResolver, IServiceRegistrar serviceRegistrar, IServiceGenerator serviceGenerator, IServiceFinder serviceFinder, IServiceInitializer serviceInitializer, ITypeExisterChecker typeExisterChecker, IServiceIsAutoValueChecker serviceIsAutoValueChecker, ITypeGetter typeGetter)
        {
            ServiceResolver = serviceResolver;
            ServiceRegistrar = serviceRegistrar;
            ServiceGenerator = serviceGenerator;
            ServiceFinder = serviceFinder;
            ServiceInitializer = serviceInitializer;
            TypeExisterChecker = typeExisterChecker;
            ServiceIsAutoValueChecker = serviceIsAutoValueChecker;
            TypeGetter = typeGetter;
        }

        public object Resolve(Type key)
        {
            if (!TypeExisterChecker.Check(Services, key))
            {
                FallbackConfiguration.TypeNotRegistered(key, this);
            }
            
            Service service = ServiceFinder.Find(Services, key);
            object result = ServiceResolver.Resolve(service, this);

            return result;
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);
            
            if (!TypeExisterChecker.Check(Services, type))
            {
                FallbackConfiguration.TypeNotRegistered(type, this);
            }
            
            Service service = ServiceFinder.Find(Services, type);
            return (T) ServiceResolver.Resolve(service, this);
        }

        public bool Has(Type key)
        {
            Service service = ServiceFinder.Find(Services, key);

            return service != null;
        }

        public void Register(Type type)
        {
            Service service = ServiceGenerator.GenerateService(type);

            if (ServiceIsAutoValueChecker.Check(service))
            {
                ServiceInitializer.Initialize(service, this);
            }

            ServiceRegistrar.Register(Services, service, this);
        }

        public void RegisterObject(object instance)
        {
            Service service = ServiceGenerator.GenerateService(TypeGetter.GetType(instance), instance);
            ServiceRegistrar.Register(Services, service, this);
        }

        public void RegisterObject<TKey>(object instance)
        {
            Service service = ServiceGenerator.GenerateService(typeof(TKey), instance);
            ServiceRegistrar.Register(Services, service, this);
        }

        public void RegisterObject(object instance, Type targetType)
        {
            Service service = ServiceGenerator.GenerateService(targetType, instance);
            ServiceRegistrar.Register(Services, service, this);
        }

        public void RegisterAssembly(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                ServiceRegistrar.Register(Services, ServiceGenerator.GenerateService(type), this);
            }
        }

        public void RegisterAssembly<T>()
        {
            foreach (Type type in typeof(T).Assembly.GetTypes())
            {
                ServiceRegistrar.Register(Services, ServiceGenerator.GenerateService(type), this);
            }
        }

        public void RegisterAssemblies(params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    ServiceRegistrar.Register(Services, ServiceGenerator.GenerateService(type), this);
                }
            }
        }

        public void Register<T>()
        {
            Service service = ServiceGenerator.GenerateService(typeof(T));

            if (ServiceIsAutoValueChecker.Check(service))
            {
                ServiceInitializer.Initialize(service, this);
            }

            ServiceRegistrar.Register(Services, service, this);
        }
    }
}