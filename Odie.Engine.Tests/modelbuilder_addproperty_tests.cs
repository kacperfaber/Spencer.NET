using NUnit.Framework;
using Odie.Engine.Builders;

namespace Odie.Engine.Tests
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
            Assert.DoesNotThrow(() => exec(new ModelBuilder(), null));
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
    }
}