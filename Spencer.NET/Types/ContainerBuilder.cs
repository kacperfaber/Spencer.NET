using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ContainerBuilder
    {
        private List<IContainerRegistration> Registrations { get; set; } = new List<IContainerRegistration>();

        public IContainerRegistrationConvertersProvider ContainerRegistrationConvertersProvider;
        public IContainerRegistrationConverterUser ContainerRegistrationConverterUser;

        public StorageBuilder StorageBuilder = new StorageBuilder();

        public ContainerBuilder(IContainerRegistrationConvertersProvider containerRegistrationConvertersProvider, IContainerRegistrationConverterUser containerRegistrationConverterUser)
        {
            ContainerRegistrationConvertersProvider = containerRegistrationConvertersProvider;
            ContainerRegistrationConverterUser = containerRegistrationConverterUser;
        }
        
        public ContainerBuilder()
        {
            ContainerRegistrationConvertersProvider = new ContainerRegistrationConvertersProvider(new ContainerRegistrationConverterTypesProvider(), new ContainerRegistrationConvertersCreator(new ContainerRegistrationConverterCreator()));
            ContainerRegistrationConverterUser=new ContainerRegistrationConverterUser();
        }

        public ClassRegistrationBuilder RegisterClass<T>() where T : class
        {
            ClassRegistration registration = new ClassRegistration()
            {
                Class = typeof(T)
            };

            Registrations.Add(registration);

            InterfaceGenerator interfaceGenerator = new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker());

            return new ClassRegistrationBuilder(registration, new ConstructorParametersByObjectsGenerator(new TypeGetter()),
                new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),
                    new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(), interfaceGenerator),
                new MemberGenerator(new MemberFlagsGenerator()), interfaceGenerator);
        }

        public AssemblyRegistrationBuilder RegisterAssembly(Assembly assembly)
        {
            AssemblyRegistration registration = new AssemblyRegistration()
            {
                Assembly = assembly
            };

            Registrations.Add(registration);

            return new AssemblyRegistrationBuilder(registration);
        }

        public void Register(Type type)
        {
            StorageBuilder.Register(type);
        }

        public void Register<T>() where T : class
        {
            StorageBuilder.Register<T>();
        }

        public void RegisterObject<T>(T instance)
        {
            StorageBuilder.RegisterObject<T>(instance);
        }

        public IContainer Container()
        {
            List<IContainerRegistrationConverter> converters = ContainerRegistrationConvertersProvider.ProvideConverters(GetType().Assembly);

            foreach (IContainerRegistration registration in Registrations)
            {
                IEnumerable<IService> services = ContainerRegistrationConverterUser.UseConverter(registration, converters);
                StorageBuilder.RegisterServices(services);
            }

            IStorage storage = StorageBuilder.Build();
            return ContainerFactory.Container(storage);
        }

        public IReadOnlyContainer ReadOnlyContainer()
        {
            List<IContainerRegistrationConverter> converters = ContainerRegistrationConvertersProvider.ProvideConverters(GetType().Assembly);

            foreach (IContainerRegistration registration in Registrations)
            {
                IEnumerable<IService> services = ContainerRegistrationConverterUser.UseConverter(registration, converters);
                StorageBuilder.RegisterServices(services);
            }

            IStorage storage = StorageBuilder.Build();
            return ContainerFactory.ReadOnlyContainer(storage); 
        }
    }
}