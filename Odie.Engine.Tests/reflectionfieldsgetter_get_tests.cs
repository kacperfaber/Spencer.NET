using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Engine.Tests
{
    public class reflectionfieldsgetter_get_tests
    {
        class Test
        {
            public string X { get; set; }

            public string Y { get; set; }

            public string Z;
        }

        IEnumerable<ReflectionField> exec<T>(MemberType type)
        {
            ReflectionFieldsGetter getter = new ReflectionFieldsGetter(new ReflectionFieldGenerator());
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
            Assert.IsTrue(exec<Test>(MemberType.FIELD).Count() == 1);
        }

        [Test]
        public void returns_len_equals_to_3_if_target_is_field_and_property()
        {
            IEnumerable<ReflectionField> fields = exec<Test>(MemberType.PROPERTY | MemberType.FIELD);

            foreach (ReflectionField field in fields)
            {
                Console.WriteLine(field.MemberType);
            }
            
            Assert.IsTrue(fields.Count() == 3);
        }
    }
}