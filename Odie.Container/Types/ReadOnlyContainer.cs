using System;
using System.Collections.Generic;

namespace Odie
{
    public class ReadOnlyContainer : IReadOnlyContainer
    {
        public IServiceFinder ServiceFinder;
        public ITypeGetter TypeGetter;
        public IServiceInstanceResolver ServiceInstanceResolver;
        public IAssemblyRegistrar AssemblyRegistrar;

        public ReadOnlyContainer(IServiceFinder serviceFinder, ITypeGetter typeGetter, IServiceInstanceResolver serviceInstanceResolver, IAssemblyRegistrar assemblyRegistrar)
        {
            ServiceFinder = serviceFinder;
            TypeGetter = typeGetter;
            ServiceInstanceResolver = serviceInstanceResolver;
            AssemblyRegistrar = assemblyRegistrar;
            Storage = new Storage();
        }

        public object Resolve(Type type)
        {
            IService service = ServiceFinder.Find(Storage.Services, type);
            object result = ServiceInstanceResolver.ResolveInstance(service, this);

            return result;
        }

        public T Resolve<T>()
        {
            Type type = TypeGetter.GetType<T>();
            IService service = ServiceFinder.Find(Storage.Services, type);

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

        public IStorage Storage { get; set; }
    }
}