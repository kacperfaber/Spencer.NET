using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class enumerablegenerator_generateenumerable_tests
    {
        object exec<T>()
        {
            Type type = typeof(IEnumerable<>).MakeGenericType(typeof(T));

            EnumerableGenerator generator = new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator());
            return generator.GenerateEnumerable(type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<int>());
        }

        [Test]
        public void returns_type_equals_List()
        {
            Assert.AreEqual(typeof(List<int>), exec<int>().GetType());
        }

        [Test]
        public void enumerable_of_int_is_assignable_from_returns_type_with_generic_int()
        {
            Assert.IsTrue(exec<int>() is IEnumerable<int>);
        }

        [Test]
        public void enumerable_of_string_is_assignable_from_returns_type_with_generic_string()
        {
            Assert.IsTrue(exec<string>() is IEnumerable<string>);
        }
        
        [Test]
        public void enumerable_of_bool_is_assignable_from_returns_type_with_generic_bool()
        {
            Assert.IsTrue(exec<bool>() is IEnumerable<bool>);
        }
    }
}