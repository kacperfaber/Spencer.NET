using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class defaultconstructorinfoprovider_providedefaultconstructor_tests
    {
        class TestClass
        {
        }

        class PrivateConstructor
        {
            PrivateConstructor()
            {
            }
        }

        interface IDependency1
        {
        }

        interface IDependency2
        {
        }

        class ManyConstructors
        {
            public ManyConstructors(IDependency1 dependency1)
            {
            }

            public ManyConstructors(IDependency1 dependency1, IDependency2 dependency2)
            {
            }
        }

        ConstructorInfo exec<T>()
        {
            return new DefaultConstructorInfoProvider().ProvideDefaultConstructor(typeof(T).GetConstructors());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_default_constructor_with_empty_parameters()
        {
            Assert.IsTrue(exec<TestClass>().GetParameters().Length == 0);
        }

        [Test]
        public void returns_null_if_target_was_PrivateConstructor_class()
        {
            Assert.Null(exec<PrivateConstructor>());
        }

        [Test]
        public void returns_public_constructor_with_single_IDependency1_if_target_was_ManyConstructors()
        {
            Assert.AreEqual(typeof(IDependency1), exec<ManyConstructors>().GetParameters().FirstOrDefault().ParameterType);
        }
    }
}