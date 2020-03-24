using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class hello_world
    {
        [SingleInstance]
        class Odie
        {
            public string Name = "not-assigned";
            
            [Factory]
            public static Odie FactoryMethod()
            {
                return new Odie() {Name = "SIEMA"};
            }
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Odie>();

            Odie odie = container.Resolve<Odie>();
            Console.WriteLine(odie.Name);
        }
    }
}