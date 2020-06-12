using System;
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

        class Florka : IFlorka
        {
            [Inject]
            public Tobi Tobi { get; set; }

            public string Name { get; set; }

            public Florka(string name)
            {
                Name = name;
            }
        }

        class Tobi
        {
            public Tobi(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }

        [Test]
        public void another_test()
        {
            IStorage storage = new StorageBuilder()
                .Register<Tobi>("Tobisiek")
                .Register<Florka>("Florka potworka")
                .Build();

            IContainer container = ContainerFactory.Container(storage);

            IFlorka florka = container.Resolve<IFlorka>();
        }
    }

    [MultiInstance]
    public class MultiInstanceObject
    {
    }
}