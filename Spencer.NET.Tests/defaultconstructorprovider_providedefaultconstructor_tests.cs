using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class defaultconstructorprovider_providedefaultconstructor_tests
    {
        class Test1
        {
        }

        ConstructorInfo exec<T>()
        {
            DefaultConstructorProvider d = new DefaultConstructorProvider();
            return d.ProvideDefaultConstructor(TODO);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1>());
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<Test1>());
        }

        [Test]
        public void returns_instanceof_memberinfo()
        {
            Assert.IsTrue(exec<Test1>() is MemberInfo);
        }

        [Test]
        public void returns_membertype_of_constructor()
        {
            Assert.IsTrue(exec<Test1>().MemberType == MemberTypes.Constructor);
        }

        [Test]
        public void returns_constructor_parameters_len_equals_to_0()
        {
            Assert.IsTrue(exec<Test1>().GetParameters().Length == 0);
        }
    }
}