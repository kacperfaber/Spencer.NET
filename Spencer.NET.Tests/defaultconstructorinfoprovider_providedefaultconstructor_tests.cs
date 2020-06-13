using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class defaultconstructorinfoprovider_providedefaultconstructor_tests
    {
        class TestClass
        {
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
    }
}