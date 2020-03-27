using NUnit.Framework;

namespace Odie.Container.Tests
{
    [MultiInstance]
    public class test
    {
        void exec()
        {
            
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<test>();
            
            test t1 = container.Resolve<test>();
            test t2 = container.Resolve<test>();
        }
    }
}