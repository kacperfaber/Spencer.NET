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
            
            return new ClassRegistrationBuilder(registration, new ConstructorParametersByObjectsGenerator(new TypeGetter()), new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()), new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(), new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())), new MemberGenerator(new MemberFlagsGenerator()));
        }

        public void RegisterInterface<T>()
        {
        }

        public void RegisterAssembly(Assembly assembly)
        {
        }

        public void Register(Type type)
        {
        }

        public void Register<T>()
        {
        }
    }
}