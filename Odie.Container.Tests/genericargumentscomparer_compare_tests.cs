using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class genericargumentscomparer_compare_tests
    {
        class Test1 <T1, T2>
        {
        }

        class Test2 <T1, T2>
        {
        }

        bool exec<T1, T2>()
        {
            return new GenericArgumentsComparer().Compare(typeof(T1).GetGenericArguments().AsEnumerable(), typeof(T2).GetGenericArguments().AsEnumerable());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1<int, int>, Test2<int, int>>());
        }

        [Test]
        public void returns_true_if_gived_was_same_generic_list_of_same_type()
        {
            Assert.IsTrue(exec<Test1<int, int>, Test1<int, int>>());
        }
        
        [Test]
        public void returns_true_if_gived_was_same_generic_list_of_another_type()
        {
            Assert.IsTrue(exec<Test1<int, int>, Test2<int, int>>());
        }

        [Test]
        public void returns_false_if_gived_was_other_generic_list_of_same_type()
        {
            Assert.IsFalse(exec<Test1<int, int>, Test1<string, string>>());
        }
        
        [Test]
        public void returns_false_if_gived_was_other_generic_list_of_another_type()
        {
            Assert.IsFalse(exec<Test1<int, int>, Test2<string, string>>());
        }
    }
}