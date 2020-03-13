using System;
using NUnit.Framework;
using Odie.Container;

namespace Odie.Container.Tests
{
    [SingleInstance]
    public class container
    {
        public string x;
        
        [Test]
        public void xxx()
        {
            Container container = new Container();
            container.Register<container>();
            container.Resolve<container>().x = "hello world";

            container containerInstance = container.Resolve<container>();
            Assert.AreEqual(containerInstance.x, "hello world");

            Console.WriteLine(containerInstance != null);
        }
    }
}