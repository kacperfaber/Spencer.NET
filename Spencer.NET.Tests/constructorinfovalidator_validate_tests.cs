using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class constructorinfovalidator_validate_tests
    {
        class PublicConstructor
        {
            public PublicConstructor()
            {
            }
        }

        class PrivateConstructor
        {
            PrivateConstructor()
            {
            }
        }

        bool exec<TClass>(bool @public = false) where TClass : class
        {
            BindingFlags flag = @public ? BindingFlags.Public : BindingFlags.NonPublic;
            return new ConstructorInfoValidator().Validate(typeof(TClass).GetConstructors(BindingFlags.Instance | flag).First());
        }

        [Test]
        public void dont_throws_exceptions_when_target_was_public_constructor()
        {
            Assert.DoesNotThrow(() => exec<PublicConstructor>(true));
        }

        [Test]
        public void dont_throws_exceptions_when_target_was_private_constructor()
        {
            Assert.DoesNotThrow(() => exec<PrivateConstructor>());
        }

        [Test]
        public void returns_true_if_constructor_is_public()
        {
            Assert.IsTrue(exec<PublicConstructor>(true));
        }

        [Test]
        public void returns_false_if_constructor_is_private()
        {
            Assert.IsFalse(exec<PrivateConstructor>());
        }
    }
}