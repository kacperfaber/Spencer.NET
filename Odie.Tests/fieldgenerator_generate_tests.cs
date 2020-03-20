using System;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;

namespace Odie.Tests
{
    public class fieldgenerator_generate_tests
    {
        class ValueGenerator : IFieldValueGenerator
        {
            public object GenerateValue(Property property, out Type outputType)
            {
                outputType = typeof(object);
                return null;
            }
        }

        Field exec(Action<PropertyBuilder> act, IFieldValueGenerator valueGenerator)
        {
            PropertyBuilder b = new PropertyBuilder();
            act(b);

            return new FieldGenerator(new FieldBuilder(), valueGenerator).Generate(b.Build());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(b => {}, new ValueGenerator()));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(b => { b.AddName("property"); }, new ValueGenerator()));
        }

        [TestCase("property")]
        [TestCase("hello_world")]
        [TestCase("siema")]
        public void returns_name_gived_in_testcase(string name)
        {
            Field field = exec(b => b.AddName(name), new ValueGenerator());

            Assert.AreEqual(name, field.Name);
        }

        [Test]
        public void returns_null_value_with_gived_dependency_ValueGenerator()
        {
            Field field = exec(b => {}, new ValueGenerator());
            
            Assert.Null(field.Value);
        }

        [Test]
        public void returns_output_type_equals_to_object_with_gived_dependency_ValueGenerator()
        {
            Field field = exec(b => { }, new ValueGenerator());
            
            Assert.AreEqual(typeof(object), field.Type);
        }

        [Test]
        public void throws_exception_when_gived_dependency_is_FieldValueGenerator_and_generator_wasnt_injected()
        {
            Exception exception = Assert.Catch<Exception>(() => exec(b => {}, new FieldValueGenerator()));
            
            Assert.NotNull(exception);
        }
    }
}