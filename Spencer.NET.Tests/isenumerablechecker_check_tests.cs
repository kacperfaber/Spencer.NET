using System.Collections.Generic;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class isenumerablechecker_check_tests
    {
        class Hello
        {
        }

        class World<T>
        {
        }

        bool exec<T>()
        {
            IsEnumerableChecker checker = new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(),
                new TypeContainsGenericParametersChecker());
            return checker.Check(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<List<int>>());
        }

        [Test]
        public void returns_true_if_gived_is_list_with_generic_int()
        {
            Assert.IsTrue(exec<List<int>>());
        }

        [Test]
        public void returns_false_if_gived_is_other_type_not_derrivering_of_ienumerable()
        {
            Assert.IsFalse(exec<Hello>());
        }

        [Test]
        public void returns_false_if_gived_is_generic_type()
        {
            Assert.IsFalse(exec<World<int>>());
        }
    }
}