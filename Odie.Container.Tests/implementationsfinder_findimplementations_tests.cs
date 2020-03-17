using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Container.Tests
{
    public class implementationsfinder_findimplementations_tests
    {
        class MyCreator : IInstanceCreator
        {
            public object CreateInstance(ServiceFlags flags, Type type, IContainer container)
            {
                throw new NotImplementedException();
            }
        }
        
        IEnumerable<Type> exec<T>()
        {
            AssemblyList list = new AssemblyList();
            list.AddAssembly(Assembly.GetCallingAssembly());
            list.AddAssembly(Assembly.GetExecutingAssembly());
            list.AddAssembly(Assembly.GetEntryAssembly());
            list.AddAssemblies(GetType().Assembly.GetReferencedAssemblies());
            
            ImplementationsFinder finder = new ImplementationsFinder();
            return finder.FindImplementations(list, typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<IDisposable>());
        }

        [Test]
        public void returns_x()
        {
            foreach (Type type in exec<IInstanceCreator>())
            {
                Console.WriteLine($"type {type.Name} implements {typeof(IInstanceCreator).Name}");
            }
        }

        [TestCase(typeof(INamespaceInterfaceValidator))]
        [TestCase(typeof(IContainerResolver))]
        [TestCase(typeof(IDefaultConstructorProvider))]
        public void service_generator(Type i)
        {
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(), new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()), new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator())), new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())), new ServiceInfoGenerator()));

            AssemblyList list = new AssemblyList();
            list.AddAssembly(Assembly.GetCallingAssembly());
            list.AddAssembly(Assembly.GetExecutingAssembly());
            list.AddAssembly(Assembly.GetEntryAssembly());
            list.AddAssemblies(GetType().Assembly.GetReferencedAssemblies());

            IEnumerable<Service> services = generator.GenerateServices(i, list, null);

            foreach (Service service in services)
            {
                Console.WriteLine($"service {service.Registration.TargetType.Name} after gived {i.Name}");
            }
        }
    }
}