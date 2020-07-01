using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Spencer.NET.Tests
{
    public class builder_update_tests
    {
        class TestClass
        {
        }

        class TestBuilder : Builder<TestClass, TestBuilder, TestClass>
        {
            public TestBuilder(TestClass test = null) : base(test)
            {
            }
        }

        TestBuilder exec(TestBuilder builder, Action<TestClass> action)
        {
            return builder.Update(action);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new TestBuilder(), x => { }));
        }

        [Test]
        public void returns_same_instance_of_builder()
        {
            TestBuilder builder = new TestBuilder();
            Assert.AreEqual(exec(builder, x => { }), builder);
        }

        [Test]
        public void returns_Object_not_null_tests()
        {
            TestBuilder builder = new TestBuilder();
            
            Assert.NotNull(exec(builder, x => { }).Object);
        }

        [Test]
        public void returns_same_Object()
        {
            TestBuilder builder = new TestBuilder();

            Assert.AreEqual(builder.Object, exec(builder, x => {}).Object);
        }

        [Test]
        public void gives_same_Object_from_TestBuilder_instance_to_invoke_Action()
        {
            TestBuilder builder = new TestBuilder();

            exec(builder, x => Assert.AreEqual(builder.Object, x));
        }
    }
}