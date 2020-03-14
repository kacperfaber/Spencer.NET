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

        interface ITest
        {
            string Name { get; set; }
        }

        class Test : ITest
        {
            public string Name { get; set; } = "KacpiiToZiomal";
        }

        [Test]
        public void xxx()
        {
            
        }
    }
}