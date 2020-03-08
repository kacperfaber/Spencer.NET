using NUnit.Framework;

namespace Odie.Base.Tests
{
    public class serviceloader_has_generic
    {
        class Hello
        {
        }

        class World
        {
        }

        bool exec<T>()
        {
            ServiceLoader.Current.Register(typeof(Hello));

            return ServiceLoader.Current.Has(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Hello>());
        }

        [Test]
        public void returns_true_if_target_is_hello()
        {
            Assert.IsTrue(exec<Hello>());
        }

        [Test]
        public void returns_false_if_target_is_world()
        {
            Assert.IsFalse(exec<World>());
        }
    }
}