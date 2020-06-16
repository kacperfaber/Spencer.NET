using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class ContainerBuilder
    {
        private List<IContainerRegistration> Registrations { get; set; } = new List<IContainerRegistration>();

        public ClassRegistrationBuilder RegisterClass<T>() where T : class
        {
            ClassRegistration registration = new ClassRegistration()
            {
                Type = typeof(T)
            };

            Registrations.Add(registration);

            InterfaceGenerator interfaceGenerator = new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker());
            return new ClassRegistrationBuilder(registration, new ConstructorParametersByObjectsGenerator(new TypeGetter()),
                new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),
                    new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(), interfaceGenerator),
                new MemberGenerator(new MemberFlagsGenerator()), interfaceGenerator);
        }

        public void RegisterInterface<T>()
        {
        }

        public void RegisterAssembly(Assembly assembly)
        {
        }

        public void Register(Type type)
        {
            // that is registering type or interfaces without builders.
        }

        public void Register<T>()
        {
            // that is registering type or interfaces without builders.
        }
    }
}