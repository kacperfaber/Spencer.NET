using NUnit.Framework;

namespace Odie.Tests
{
    public class booleangenerator_generate_tests
    {
        bool exec<TArg>(TArg @true)
        {
            return (bool) StaticContainer.Current.Resolve<BooleanGenerator>()
                .Generate(@true, typeof(TArg), new[] {typeof(bool)}, out _);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(.5f));
        }

        [Test]
        public void returns_true_if_float_arg_is_1f()
        {
            Assert.IsTrue(exec(1f));
        }

        [Test]
        public void returns_false_if_float_arg_is_0f()
        {
            Assert.IsFalse(exec(0f));
        }
    }
}