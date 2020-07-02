using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class memberbuilder_addflag_tests
    {
        MemberBuilder exec(MemberBuilder builder, int flag)
        {
            return builder.AddFlag(flag);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new MemberBuilder(), 0x0));
        }

        [Test]
        public void returns_same_builder_instance()
        {
            MemberBuilder builder = new MemberBuilder();
            Assert.AreEqual(builder, exec(builder, 0));
        }

        [Test]
        public void returns_same_object_instance()
        {
            MemberBuilder builder = new MemberBuilder();
            Assert.AreEqual(builder.Object, exec(builder, 0).Object);
        }

        [Test]
        public void returns_not_null_MemberFlags_instance()
        {
            Assert.NotNull(exec(new MemberBuilder(), 0).Object.MemberFlags);
        }

        [Test]
        public void returns_MemberFlags_greater_than_was()
        {
            MemberBuilder builder = new MemberBuilder();
            int before = builder.Object.MemberFlags.Count;
            exec(builder, 0);
            int after = builder.Object.MemberFlags.Count;
            
            Assert.IsTrue(before < after);
        }

        [TestCase(0x0)]
        [TestCase(0x05)]
        [TestCase(0x105)]
        [TestCase(-0x02)]
        [TestCase(-0x055)]
        [TestCase(-0x02412)]
        public void returns_MemberFlags_contains_gived_flag(int flag)
        {
            MemberBuilder builder = new MemberBuilder();
            exec(builder, flag);
            
            Assert.NotNull(builder.Object.MemberFlags.SingleOrDefault(x => x == flag));
        }
    }
}