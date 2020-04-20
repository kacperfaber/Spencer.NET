using System;
using System.Collections.Generic;
using Spencer.NET.Exceptions;

namespace Spencer.NET
{
    public class ReadOnlyContainer : IReadOnlyContainer
    {
        public IServiceFinder ServiceFinder;
        public ITypeGetter TypeGetter;
        public IServiceInstanceResolver ServiceInstanceResolver;
        public IAssemblyRegistrar AssemblyRegistrar;
        public IServiceRegistrar ServiceRegistrar;
        public IServicesGenerator ServicesGenerator;

        public ReadOnlyContainer(IServiceFinder serviceFinder, ITypeGetter typeGetter, IServiceInstanceResolver serviceInstanceResolver,
            IAssemblyRegistrar assemblyRegistrar, IServiceRegistrar serviceRegistrar, IServicesGenerator servicesGenerator)
        {
            ServiceFinder = serviceFinder;
            TypeGetter = typeGetter;
            ServiceInstanceResolver = serviceInstanceResolver;
            AssemblyRegistrar = assemblyRegistrar;
            ServiceRegistrar = serviceRegistrar;
            ServicesGenerator = servicesGenerator;
            
            Storage = new Storage();
        }

        public object Resolve(Type type)
        {
            IService service = ServiceFinder.Find(Storage.Services, type);
            
            if (service == null)
                throw new ResolveException(type);

            object result = ServiceInstanceResolver.ResolveInstance(service, this);

            return result;
        }

        public T Resolve<T>()
        {
            Type type = TypeGetter.GetType<T>();
            IService service = ServiceFinder.Find(Storage.Services, type);

            if (service == null)
                throw new ResolveException(type);
            
            return (T) ServiceInstanceResolver.ResolveInstance(service, this);
        }

        public IEnumerable<T> ResolveMany<T>()
        {
            Type type = TypeGetter.GetType<T>();

            IEnumerable<IService> services = ServiceFinder.FindMany(Storage.Services, type);

            foreach (IService service in services)
            {
                yield return (T) ServiceInstanceResolver.ResolveInstance(service, this);
            }
        }

        public IEnumerable<object> ResolveMany(Type type)
        {
            IEnumerable<IService> services = ServiceFinder.FindMany(Storage.Services, type);

            foreach (IService service in services)
            {
                yield return ServiceInstanceResolver.ResolveInstance(service, this);
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

        public virtual IStorage Storage { get; set; }
    }
}