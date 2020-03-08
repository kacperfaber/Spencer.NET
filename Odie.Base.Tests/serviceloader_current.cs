using NUnit.Framework;

namespace Odie.Base.Tests
{
    public class serviceloader_current
    {
        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() =>
            {
                ServiceLoader x = ServiceLoader.Current;
            });
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(ServiceLoader.Current);
        }

        [Test]
        public void returns_same_instance_all_of_time()
        {
            ServiceLoader loader1 = ServiceLoader.Current;
            loader1.Register<serviceloader_current>();
            
            ServiceLoader loader2 = ServiceLoader.Current;
            Assert.IsTrue(loader2.Has(typeof(serviceloader_current)));
        }
    }
}