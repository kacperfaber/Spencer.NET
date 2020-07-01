using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class genericclassfinder_findclasses_tests
    {
        class GenericClass<T1, T2>
        {
        }

        IEnumerable<IService> exec<TRegister, TResolve>()
        {
            Type registerType = typeof(TRegister);
            Type resolveType = typeof(TResolve);

            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(),
                ServiceGeneratorFactory.MakeInstance());

            IEnumerable<IService> services = generator.GenerateServices(registerType, new AssemblyList());
            ServiceList list = new ServiceList();

            list.AddServices(services.ToArray());

            GenericClassFinder finder = new GenericClassFinder(new TypeGenericParametersProvider());
            return finder.FindClasses(list, resolveType);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<GenericClass<int, int>, GenericClass<int, int>>());
        }

        [Test]
        public void returns_single_item_if_resolve_type_was_registered_type()
        {
            IEnumerable<IService> services = exec<GenericClass<int, int>, GenericClass<int, int>>();

            Assert.IsTrue(services.Count() == 1);
        }

        [Test]
        public void returns_empty_if_resolve_type_has_others_parameters_than_registered_type()
        {
            IEnumerable<IService> services = exec<GenericClass<int, int>, GenericClass<bool, bool>>();
            
            Assert.IsEmpty(services);
        }

        [Test]
        public void returns_empty_if_only_second_parameter_was_different()
        {
            IEnumerable<IService> services = exec<GenericClass<int, int>, GenericClass<int, bool>>();
            
            Assert.IsEmpty(services);
        }

        [Test]
        public void returns_empty_if_only_first_parameter_was_different()
        {
            IEnumerable<IService> services = exec<GenericClass<int, int>, GenericClass<bool, int>>();
            
            Assert.IsEmpty(services);
        }

        [Test]
        public void returns_empty_if_registered_parameters_object_and_resolve_is_ints()
        {
            IEnumerable<IService> services = exec<GenericClass<object, object>, GenericClass<int, int>>();
            
            Assert.IsEmpty(services);
        }
    }
}