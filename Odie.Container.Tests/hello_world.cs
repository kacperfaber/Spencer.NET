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
            [FactoryResult(typeof(Odie))]
            public static Odie FactoryMethod(hello_world world)
            {
                Console.WriteLine(world);
                return new Odie() {Name = "world is " + world == null ? "NULL" : "NOT NULL"};
            }
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Odie>();
            
            Odie resolve = container.Resolve<Odie>();
        }
    }
}