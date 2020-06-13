using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class StorageBuilder : Builder<Storage, StorageBuilder, IStorage>, IDisposable
    {
        private IServicesGenerator ServicesGenerator;
        private IServiceRegistrar ServiceRegistrar;
        private IAssemblyRegistrar AssemblyRegistrar;
        public IConstructorParametersByObjectsGenerator ConstructorParametersGenerator;

        public StorageBuilder(Storage storage = null) : base(storage)
        {
            ServicesGenerator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new ServiceGenerator(
                    new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())),
                        new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new ServiceRegistrationFlagGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()), new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(), new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator())), new ConstructorInfoListGenerator(), new DefaultConstructorInfoProvider())),
                    new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(),
                    new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                        new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                            new ServiceHasConstructorParametersChecker()),
                        new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),
                            new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(),
                        new ConstructorFinder(), new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                        new ParametersValuesExtractor()))), new ServiceFactoryInvoker()));

            ServiceRegistrar = new ServiceRegistrar(
                new ServiceInstanceProvider(
                    new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                        new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                            new ServiceHasConstructorParametersChecker()),
                        new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),
                            new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(),
                        new ConstructorFinder(), new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                        new ParametersValuesExtractor())), new ServiceIsAutoValueChecker()), new ServiceInstanceChecker(), new RegistratedServicesFilter());

            AssemblyRegistrar = new AssemblyRegistrar(new AssemblyListAdder(), new AssemblyListContainsChecker());
            
            ConstructorParametersGenerator = new ConstructorParametersByObjectsGenerator(new TypeGetter());
        }

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
            IConstructorParameters parameters = ConstructorParametersGenerator.GenerateParameters(constructorParameters);

            return Update(x =>
            {
                Type type = typeof(T);
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(typeof(T), Object.Assemblies, null, parameters);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public StorageBuilder Register(Type type, params object[] constructorParameters)
        {
            IConstructorParameters parameters = ConstructorParametersGenerator.GenerateParameters(constructorParameters);
            
            return Update(x =>
            {
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Object.Assemblies, null, parameters);
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

        public StorageBuilder RegisterObject(object instance)
        {
            return Update(x =>
            {
                Type type = instance.GetType();
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(type, Object.Assemblies, instance: instance);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public StorageBuilder RegisterObject<T>(T instance)
        {
            return Update(x =>
            {
                Type type = typeof(T);
                AssemblyRegistrar.RegisterIfNotExist(x.Assemblies, type.Assembly);
                IEnumerable<IService> services = ServicesGenerator.GenerateServices(typeof(T), Object.Assemblies, instance: instance);
                ServiceRegistrar.Register(Object.Services, services);
            });
        }

        public void Dispose()
        {
        }
    }
}