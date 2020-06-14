using System;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class hello_world
    {
        [SingleInstance]
        class Odie
        {
            public string Name = "not-assigned";

            [Factory]
            public static Odie FactoryMethod(hello_world world)
            {
                Console.WriteLine(world);
                return new Odie() {Name = "world is " + world == null ? "NULL" : "NOT NULL"};
            }
        }

        [AutoValue]
        class HelloWorld
        {
#pragma warning disable
            [Factory]
            public static HelloWorld GetWorld()
            {
                return new HelloWorld()
                {
                    Name = "Odie from factory!!!"
                };
            }

            public string Name { get; set; }

            [Instance]
            public static HelloWorld Instance;
#pragma warning restore
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<Odie>();
            container.Register<HelloWorld>();
            container.Register<hello_world>();

            Odie resolve = container.Resolve<Odie>();
        }

        [Test]
        public void rrr()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<HelloWorld>();

            Console.WriteLine(HelloWorld.Instance.Name);
        }

        [Test]
        public void storage_builder()
        {
            IStorage storage = new StorageBuilder()
                .Register<hello_world>()
                .Register<Factory>()
                .Build();
        }

        interface IFlorka
        {
        }

        interface ITobi
        {
        }

        class Tobi : ITobi
        {
        }

        class Florka : IFlorka
        {
            [Factory]
            public Florka MakeInstance(Tobi tobi)
            {
                return new Florka();
            }
        }

        [Test]
        public void another_test()
        {
            IStorage storage = new StorageBuilder()
                .Register<Tobi>()
                .Register<IFlorka>()
                .Build();

            IContainer container = ContainerFactory.Container(storage);

            Florka florka = container.Resolve<Florka>();
        }
    }

    [MultiInstance]
    public class MultiInstanceObject
    {
    }
}