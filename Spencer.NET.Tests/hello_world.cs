using System;
using System.Collections.Generic;
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
            [FactoryResult(typeof(Odie))]
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
            [FactoryResult(typeof(HelloWorld))]
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
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Odie>();
            container.Register<HelloWorld>();
            container.Register<hello_world>();

            Odie resolve = container.Resolve<Odie>();
        }

        [Test]
        public void rrr()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<HelloWorld>();

            Console.WriteLine(HelloWorld.Instance.Name);
        }

        class Test2
        {
        }

        class Test1
        {
        }

        class TestClass
        {
            [Inject]
            public Test2 Inject { get; set; }
            
            [TryInject]
            public Test1 TryInject { get; set; }

            [Auto]
            public IEnumerable<Test1> Tests { get; set; }
        }

        [Test]
        public void auto_and_inject()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Test2>();
            container.Register<TestClass>();

            TestClass testClass = container.Resolve<TestClass>();
        }
    }
}