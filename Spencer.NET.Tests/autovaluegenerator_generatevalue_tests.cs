using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class autovaluegenerator_generatevalue_tests
    {
        object exec(Type type)
        {
            AutoValueGenerator generator = new AutoValueGenerator(
                new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()),
                new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new TypeIsArrayChecker(), new ArrayGenerator(),
                new TypeIsValueTypeChecker(), new ValueTypeActivator());

            return generator.GenerateValue(type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(typeof(int)));
        }

        [TestCase(typeof(int))]
        [TestCase(typeof(uint))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void returns_valuetype_if_targettype_was_valuetype(Type type)
        {
            Assert.IsTrue(exec(type).GetType().IsValueType);
        }

        [TestCase(typeof(int))]
        [TestCase(typeof(uint))]
        [TestCase(typeof(long))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void returns_default_value_of_valuetype_if_target_was_valuetype(Type type)
        {
            object o = exec(type);

            if (o is int i)
            {
                Assert.IsTrue(i == default);
            }

            else if (o is float f)
            {
                Assert.IsTrue(f == default);
            }

            else if (o is double d)
            {
                Assert.IsTrue(d == default);
            }

            else if (o is uint @uint)
            {
                Assert.IsTrue(@uint == default);
            }
        }

        [TestCase(typeof(int))]
        [TestCase(typeof(float))]
        [TestCase(typeof(double))]
        public void returns_empty_list_if_target_was_basing_on_IEnumerable(Type listOf)
        {
            Type enumerableOf = typeof(IEnumerable<>).MakeGenericType(listOf);

            object res = exec(enumerableOf);

            Assert.IsTrue(enumerableOf.IsInstanceOfType(res));
        }
    }
}