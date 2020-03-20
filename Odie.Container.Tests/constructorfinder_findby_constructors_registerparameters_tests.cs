using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class constructorfinder_findby_constructors_registerparameters_tests
    {
        class Kasia
        {
        }

        class Basia
        {
        }

        class Test1
        {
            public Test1(Kasia kasia)
            {
            }

            public Test1(Kasia kasia, Basia basia)
            {
            }

            public Test1(Basia basia)
            {
            }

            public Test1()
            {
            }
        }

        ConstructorInfo exec<T>(params object[] instances)
        {
            RegisterParameters parameters = new RegisterParameters();
            foreach (object instance in instances)
            {
                parameters.Add(new RegisterParameter()
                {
                    Type = instance.GetType(),
                    Value = instance
                });
            }

            ConstructorFinder finder = new ConstructorFinder();
            ConstructorInfo ctor = finder.FindBy(typeof(T).GetConstructors().Where(x => instances.Length>=x.GetParameters().Length).ToArray(), parameters);

            return ctor;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1>());
        }

        [Test]
        public void returns_basia_constructor_if_gived_instance_is_basia()
        {
            ConstructorInfo ctor = exec<Test1>(new Basia());

            Assert.IsTrue(ctor.GetParameters().Count() == 1);
            Assert.AreEqual("basia", ctor.GetParameters().FirstOrDefault().Name);
        }

        [Test]
        public void returns_kasia_basia_constructor_if_gived_instances_is_kasia_and_basia()
        {
            ConstructorInfo ctor = exec<Test1>(new Kasia(), new Basia());

            int count = ctor.GetParameters().Count();

            Console.WriteLine(count);
            Console.WriteLine(ctor.GetParameters().First().Name);
            Console.WriteLine(ctor.GetParameters().Last().Name);
            
            Assert.IsTrue(count == 2);
            Assert.AreEqual("kasia", ctor.GetParameters().FirstOrDefault().Name);
            Assert.AreEqual("basia", ctor.GetParameters().LastOrDefault().Name);
        }
    }
}