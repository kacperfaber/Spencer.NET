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

        [Test]
        public void xxx()
        {
            AssemblyRegistrationBuilder builder = new ContainerBuilder()
                .RegisterAssembly(GetType().Assembly);

            builder
                .IncludeClass<Florka>()
                .SelectClass<Florka>()
                .AsImplementedInterfaces()
                .WithInstance(new Florka());
        }

        private hello_world New()
        {
            return new hello_world();
        }

        interface IKacpii
        {
        }

        interface IZiomal
        {
        }

        class Person<T>
        {
            public T Id { get; set; }
        }

        interface ISimpleInterface
        {
            string Simple { get; set; }
        }

        interface IGenericInterface<T>
        {
            T Object { get; set; }
        }

        interface IPersonManager
        {
            T CreateInstance<T>();
        }

        class PersonManager : IPersonManager
        {
            public T CreateInstance<T>()
            {
                return Activator.CreateInstance<T>();
            }
        }

        class Kacper : Person<int>, IGenericInterface<int>, ISimpleInterface
        {
            public string Simple { get; set; }

            public int Object { get; set; }

            public static Kacper CreateInstance(IPersonManager manager)
            {
                return manager.CreateInstance<Kacper>();
            }
        }

        class GenericClass<T>
        {
            public T Id;
        }

        [Test]
        public void builder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder
                .RegisterClass<GenericClass<int>>()
                .AsSingleInstance();

            IContainer c = builder.Container();
            GenericClass<int> g = c.Resolve<GenericClass<int>>();
        }
    }

    [MultiInstance]
    public class MultiInstanceObject
    {
    }
}