using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class constructorfinder_findby_constructors_constructorparameters_tests
    {
        class Kasia
        {
        }

        class Basia
        {
        }

        class Zenek
        {
        }

        class Lukasz
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

            public Test1(Kasia kasia, Lukasz lukasz)
            {
            }

            public Test1(Zenek zenek, Lukasz lukasz, Basia basia, Kasia kasia)
            {
            }

            public Test1(int x, int y, int z)
            {
            }
        }

        ConstructorInfo exec<T>(params object[] instances)
        {
            ConstructorParameters parameters = new ConstructorParameters();
            foreach (object instance in instances)
            {
                parameters.Add(new ConstructorParameter()
                {
                    Type = instance.GetType(),
                    Value = instance
                });
            }

            ConstructorFinder finder = new ConstructorFinder();
            ConstructorInfo[] allCtors = typeof(T).GetConstructors();
            ConstructorInfo ctor = finder.FindBy(allCtors, parameters);

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

        [Test]
        public void returns_kasia_lukasz_constructor_when_if_gived_instances_will_be_kasia_and_lukasz()
        {
            ConstructorInfo ctor = exec<Test1>(new Kasia(), new Lukasz());

            ParameterInfo[] parameters = ctor.GetParameters();

            Assert.IsTrue(parameters.Count() == 2);
            Assert.AreEqual("kasia", parameters[0].Name);
            Assert.AreEqual("lukasz", parameters[1].Name);
        }

        [Test]
        public void returns_x_y_z_constructor_when_gived_will_be_3_ints()
        {
            ConstructorInfo ctor = exec<Test1>(1, 2, 3);

            ParameterInfo[] parameters = ctor.GetParameters();

            Assert.IsTrue(parameters.Count() == 3);
            Assert.AreEqual("x", parameters[0].Name);
            Assert.AreEqual("y", parameters[1].Name);
            Assert.AreEqual("z", parameters[2].Name);
        }

        [Test]
        public void returns_empty_constructor_if_gived_will_be_any_parameters()
        {
            ConstructorInfo ctor = exec<Test1>();

            Assert.IsTrue(ctor.GetParameters().Length == 0);
        }

        [Test]
        public void returns_zenek_lukasz_basia_kasia_constructor_when_all_instances_was_gived()
        {
            ConstructorInfo ctor = exec<Test1>(new Kasia(), new Basia(), new Lukasz(), new Zenek());

            ParameterInfo[] parameters = ctor.GetParameters();

            Assert.IsTrue(parameters.Length == 4);
            Assert.AreEqual("zenek", parameters[0].Name);
            Assert.AreEqual("lukasz", parameters[1].Name);
            Assert.AreEqual("basia", parameters[2].Name);
            Assert.AreEqual("kasia", parameters[3].Name);
        }

        [Test]
        public void returns_zenek_lukasz_basia_kasia_constructor_when_all_instances_was_gived_is_random_order()
        {
            ConstructorInfo ctor = exec<Test1>(new Zenek(), new Basia(), new Kasia(), new Lukasz());

            ParameterInfo[] parameters = ctor.GetParameters();

            Assert.IsTrue(parameters.Length == 4);
            Assert.AreEqual("zenek", parameters[0].Name);
            Assert.AreEqual("lukasz", parameters[1].Name);
            Assert.AreEqual("basia", parameters[2].Name);
            Assert.AreEqual("kasia", parameters[3].Name);
        }
    }
}