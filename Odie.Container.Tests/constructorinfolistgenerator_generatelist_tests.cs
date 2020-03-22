using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class constructorinfolistgenerator_generatelist_tests
    {
        interface ITest
        {
        }

        class TestClass
        {
            public TestClass(int x, int y)
            {
            }

            public TestClass()
            {
            }

            public TestClass(string name)
            {
            }
        }

        ConstructorInfo[] exec<T>()
        {
            return new ConstructorInfoListGenerator().GenerateList(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_excepted_items_len()
        {
            Assert.IsTrue(exec<TestClass>().Length == 3);
        }

        [Test]
        public void returns_has_empty_constructor()
        {
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.GetParameters().Length == 0));
        }

        [Test]
        public void returns_has_constructor_with_2_ints_parameters()
        {
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.GetParameters().Length == 2 && x.GetParameters().All(x => x.ParameterType == typeof(int))));
        }

        [Test]
        public void returns_has_constructor_with_1_string_parameter()
        {
            Assert.NotNull(exec<TestClass>()
                .SingleOrDefault(x => x.GetParameters().Length == 1 && x.GetParameters().All(x => x.ParameterType == typeof(string))));
        }

        [Test]
        public void returns_empty_array_if_type_is_inteface()
        {
            Assert.That(exec<ITest>, Is.Empty);
        }
    }
}