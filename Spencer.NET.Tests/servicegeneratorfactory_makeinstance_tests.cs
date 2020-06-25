using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicegeneratorfactory_makeinstance_tests
    {
        IServiceGenerator exec()
        {
            return ServiceGeneratorFactory.MakeInstance();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_instance_of_ServiceGenerator()
        {
            Assert.IsTrue(exec() is ServiceGenerator);
        }

        [Test]
        public void returns_new_instance_every_time()
        {
            IServiceGenerator g1 = exec();
            IServiceGenerator g2 = exec();
            
            Assert.AreNotEqual(g1, g2);
        }
    }
}