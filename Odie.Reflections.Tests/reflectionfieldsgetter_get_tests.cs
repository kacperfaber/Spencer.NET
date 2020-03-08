using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Reflections.Tests
{
    public class reflectionfieldsgetter_get_tests
    {
        class Test
        {
            public string X { get; set; }

            public string Y { get; set; }

#pragma warning disable

            public string Z;

#pragma warning restore
        }

        IEnumerable<ReflectionField> exec<T>(MemberType type)
        {
            ReflectionFieldsGetter getter =
                new ReflectionFieldsGetter(new ReflectionFieldGenerator(new FlagsGenerator(new FlagGenerator(), new FlagAttributeTypeProvider())));
            IEnumerable<ReflectionField> fields = getter.Get(typeof(T), type);

            return fields;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test>(MemberType.PROPERTY | MemberType.FIELD));
        }

        [Test]
        public void returns_len_equals_to_2_if_target_is_property()
        {
            Assert.IsTrue(exec<Test>(MemberType.PROPERTY).Count() == 2);
        }

        [Test]
        public void returns_len_equals_to_1_if_target_is_field()
        {
            IEnumerable<ReflectionField> fields = exec<Test>(MemberType.FIELD);
            Assert.IsTrue(fields.Count() == 1);
        }

        [Test]
        public void returns_len_equals_to_3_if_target_is_field_and_property()
        {
            IEnumerable<ReflectionField> fields = exec<Test>(MemberType.PROPERTY | MemberType.FIELD);

            Assert.IsTrue(fields.Count() == 3);
        }
    }
}