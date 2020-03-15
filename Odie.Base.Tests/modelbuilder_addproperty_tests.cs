using System;
using NUnit.Framework;

namespace Odie.Base.Tests
{
    public class modelbuilder_addproperty_tests
    {
        ModelBuilder exec(ModelBuilder builder, Property prop)
        {
            return builder.AddProperty(prop);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() =>
                exec(new ModelBuilder(), null));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(new ModelBuilder(), null));
        }

        [TestCase(5)]
        [TestCase(9)]
        [TestCase(2)]
        public void returns_properties_len_matching_for_added_times(int times)
        {
            ModelBuilder b = new ModelBuilder();

            for (int i = 0; i < times; i++)
            {
                b = b.AddProperty(null);
            }

            Assert.IsTrue(b.Build().Properties.Count == times);
        }

        interface IGeneric
        {
        }

        interface IContainerItem
        {
        }

        class GenericClass<T1, T2> : IGeneric, IContainerItem
        {
            public T1 t1;
            public T2 Arg2;
        }

        [Test]
        public void generic()
        {
            StaticContainer.Current.RegisterObject(new GenericClass<int, int>() {t1 = 0, Arg2 = 5});
            StaticContainer.Current.RegisterObject(new GenericClass<string, string>() {t1 = "kacpii", Arg2 = "toziomal"});

            GenericClass<int, int> ints = StaticContainer.Current.Resolve<GenericClass<int, int>>();
            GenericClass<string, string> strings = StaticContainer.Current.Resolve<GenericClass<string, string>>();

            StaticContainer.Current.Resolve<IGeneric>();

            Console.WriteLine("");
        }
    }
}