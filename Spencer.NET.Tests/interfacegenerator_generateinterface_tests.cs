using System.Linq;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class interfacegenerator_generateinterface_tests
    {
        interface ITest
        {
        }

        interface IGenericTest<T>
        {
        }

        IInterface exec<T>()
        {
            return new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()).GenerateInterface(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest>());
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<ITest>());
        }

        [Test]
        public void returns_type_equals_to_gived_generic_type()
        {
            Assert.AreEqual(typeof(ITest), exec<ITest>().Type);
        }

        [Test]
        public void returns_hasgenericparameters_if_interface_has_generic_parameters()
        {
            Assert.IsTrue(exec<IGenericTest<int>>().HasGenericArguments);
        }

        [Test]
        public void returns_genericparameters_equals_to_generic_parameters_len()
        {
            Assert.IsTrue(exec<IGenericTest<int>>().GenericParameters.Count() == 1);
        }

        [Test]
        public void returns_genericparameters_empty_if_type_hasnt_generic_parameters()
        {
            Assert.IsEmpty(exec<ITest>().GenericParameters);
        }

        [Test]
        public void returns_genericparameters_not_empty_if_type_has_generic_parameters()
        {
            Assert.IsNotEmpty(exec<IGenericTest<int>>().GenericParameters);
        }
    }
}