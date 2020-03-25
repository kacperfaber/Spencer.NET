using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Odie.Tests
{
    public class hello_world
    {
        interface IAnimal
        {
        }

        class Garfield : IAnimal
        {
            public string Name { get; set; }

            [Factory]
            [FactoryResult(typeof(Garfield))]
            public static IAnimal CreateAnimal(Oscar oscar)
            {
                return new Garfield()
                {
                    Name = "Dog"
                };
            }
        }

        class Oscar : IAnimal
        {
        }

        [Test]
        public void hello()
        {
            IContainer container = ContainerFactory.CreateContainer();

            container.Register<Oscar>();
            container.Register<Garfield>();

            Console.WriteLine("registered Garfield.");

            Garfield garfield = container.Resolve<Garfield>();

            Console.WriteLine("resolved Gardield " + garfield.Name);
        }
    }
}