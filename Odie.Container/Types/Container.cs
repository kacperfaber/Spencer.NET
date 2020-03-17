﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class Container : IContainer
    {
        public ServicesList Services = new ServicesList();
        public AssemblyList Assemblies = new AssemblyList();

        public IServiceResolver ServiceResolver;
        public IServiceRegistrar ServiceRegistrar;
        public IServiceGenerator ServiceGenerator;
        public IServiceFinder ServiceFinder;
        public IServiceInitializer ServiceInitializer;
        public ITypeExisterChecker TypeExisterChecker;
        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker;
        public ITypeGetter TypeGetter;
        public IAssemblyRegistrar AssemblyRegistrar;
        
        public FallbackConfiguration FallbackConfiguration = new FallbackConfiguration();

        public Container(IServiceResolver serviceResolver, IServiceRegistrar serviceRegistrar, IServiceGenerator serviceGenerator, IServiceFinder serviceFinder, IServiceInitializer serviceInitializer, ITypeExisterChecker typeExisterChecker, IServiceIsAutoValueChecker serviceIsAutoValueChecker, ITypeGetter typeGetter, IAssemblyRegistrar assemblyRegistrar)
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
            Type type = TypeGetter.GetType<T>();

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
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);
            
            IEnumerable<Service> services = ServiceGenerator.GenerateServices(type, Assemblies);

            foreach (Service service in services)
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

            IEnumerable<Service> services = ServiceGenerator.GenerateServices(type, Assemblies, instance);
            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterObject<TKey>(object instance)
        {
            Type type = TypeGetter.GetType();
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, type);
            
            IEnumerable<Service> services = ServiceGenerator.GenerateServices(typeof(TKey), Assemblies, instance);
            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterObject(object instance, Type targetType)
        {
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, targetType);
            IEnumerable<Service> services = ServiceGenerator.GenerateServices(targetType, Assemblies, instance);
            ServiceRegistrar.Register(Services, services, this);
        }

        public void RegisterAssembly(Assembly assembly)
        {
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, assembly);
            
            foreach (Type type in assembly.GetTypes())
            {
                ServiceRegistrar.Register(Services, ServiceGenerator.GenerateServices(type, Assemblies), this);
            }
        }

        public void RegisterAssembly<T>()
        {
            Type tType = TypeGetter.GetType<T>();
            AssemblyRegistrar.RegisterIfNotExist(Assemblies, tType);
            
            foreach (Type type in tType.Assembly.GetTypes())
            {
                ServiceRegistrar.Register(Services, ServiceGenerator.GenerateServices(type, Assemblies), this);
            }
        }

        public void RegisterAssemblies(params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                AssemblyRegistrar.RegisterIfNotExist(Assemblies, assembly);
                
                foreach (Type type in assembly.GetTypes())
                {
                    ServiceRegistrar.Register(Services, ServiceGenerator.GenerateServices(type, Assemblies), this);
                }
            }
        }

        public void Register<T>()
        {
            IEnumerable<Service> services = ServiceGenerator.GenerateServices(typeof(T), Assemblies);

            foreach (Service service in services)
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