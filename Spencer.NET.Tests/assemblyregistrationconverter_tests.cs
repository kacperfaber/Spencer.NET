using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class assemblyregistrationconverter_tests
    {
        [Test]
        public void is_IContainerRegistrationConverter()
        {
            Assert.IsTrue(typeof(IContainerRegistrationConverter).IsAssignableFrom(typeof(AssemblyRegistrationConverter)));
        }

        [Test]
        public void is_IContainerRegistrationConverter_of_AssemblyRegistration()
        {
            Assert.IsTrue(typeof(IContainerRegistrationConverter<AssemblyRegistration>).IsAssignableFrom(typeof(AssemblyRegistrationConverter)));
        }

        [Test]
        public void has_IServiceGenerator_field()
        {
            FieldInfo field = typeof(AssemblyRegistrationConverter).GetFields().SingleOrDefault(x => x.FieldType == typeof(IServiceGenerator));

            Assert.NotNull(field);
        }

        [Test]
        public void has_empty_constructor()
        {
            ConstructorInfo constructor = typeof(AssemblyRegistrationConverter).GetConstructors().SingleOrDefault(x => x.GetParameters().Length == 0);

            Assert.NotNull(constructor);
        }

        [Test]
        public void has_one_or_more_parametrized_constructor()
        {
            IEnumerable<ConstructorInfo> constructors = typeof(AssemblyRegistrationConverter).GetConstructors().Where(x => x.GetParameters().Length > 0);

            Assert.IsNotEmpty(constructors);
        }

        [Test]
        public void has_parametrized_constructor_with_IServiceGenerator_parameter()
        {
            ConstructorInfo constructor = typeof(AssemblyRegistrationConverter)
                .GetConstructors()
                .Where(x => x.GetParameters().Length > 0)
                .SingleOrDefault(x => x.GetParameters().First().ParameterType == typeof(IServiceGenerator));

            Assert.NotNull(constructor);
        }

        [Test]
        public void IServiceGenerator_field_is_not_null_after_use_of_empty_constructor()
        {
            AssemblyRegistrationConverter converter = new AssemblyRegistrationConverter();
            IServiceGenerator generator = converter.ServiceGenerator;

            Assert.NotNull(generator);
        }

        [Test]
        public void IServiceGenerator_field_has_instance_of_ServiceGenerator_if_used_was_empty_constructor()
        {
            AssemblyRegistrationConverter converter = new AssemblyRegistrationConverter();
            IServiceGenerator generator = converter.ServiceGenerator;

            Assert.IsTrue(generator is ServiceGenerator);
        }

        [Test]
        public void IServiceGenerator_field_has_instance_equal_to_gived_in_parametrized_constructor()
        {
            IServiceGenerator generator = ServiceGeneratorFactory.MakeInstance();
            AssemblyRegistrationConverter converter = new AssemblyRegistrationConverter(generator);

            Assert.AreEqual(generator, converter.ServiceGenerator);
        }

        [Test]
        public void has_Convert_method()
        {
            MethodInfo method = typeof(AssemblyRegistrationConverter)
                .GetMethods()
                .SingleOrDefault(x => x.Name == "Convert");

            Assert.NotNull(method);
        }

        [Test]
        public void Convert_method_has_AssemblyRegistration_parameter()
        {
            MethodInfo method = typeof(AssemblyRegistrationConverter)
                .GetMethods()
                .SingleOrDefault(x => x.Name == "Convert");

            Assert.NotNull(method.GetParameters().FirstOrDefault(x => x.ParameterType == typeof(AssemblyRegistration)));
        }

        [Test]
        public void Convert_method_returns_IEnumerable_of_IService()
        {
            MethodInfo method = typeof(AssemblyRegistrationConverter)
                .GetMethods()
                .SingleOrDefault(x => x.Name == "Convert");
            
            Assert.IsTrue(method.ReturnType == typeof(IEnumerable<IService>));
        }
    }
}