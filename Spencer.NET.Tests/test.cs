using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class test
    {
        interface IManager
        {
            T CreateAnimal<T>(string name);
        }
        
        class Manager : IManager
        {
            public T CreateAnimal<T>(string name)
            {
                return (T) Activator.CreateInstance(typeof(T), new [] {name});
            }
        }
        
        interface IOdie
        {
        }

        class Odie : IOdie
        {
            public string Name { get; set; }

            public Odie()
            {
            }

            public Odie(string name)
            {
                Name = name;
            }

            [Factory(typeof(Odie))]
            public IOdie MakeOdie(Manager manager)
            {
                return manager.CreateAnimal<Odie>("Animal creator");
            }
        }

        [Test]
        public void testx()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<Manager>();
            _ = container.Resolve<Manager>();
            container.Register<Odie>();

            Odie odie = container.Resolve<Odie>();
        }
    }
}