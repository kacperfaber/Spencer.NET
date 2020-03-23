using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class generictypescomparer_compare_tests
    {
        class Test1<T1, T2>
        {
        }

        class Test2<T1, T2>
        {
        }

        bool exec<T1, T2>()
        {
            return new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()).Compare(typeof(T1), typeof(T2));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1<int, int>, Test2<int, int>>());
        }

        [Test]
        public void returns_true_if_gived_type_was_the_same_and_arguments_was_the_same()
        {
            Assert.IsTrue(exec<Test1<int, int>, Test1<int, int>>());
        }

        [Test]
        public void returns_true_if_gived_type_was_the_other_and_arguments_was_the_same()
        {
            Assert.IsTrue(exec<Test1<int, int>, Test2<int, int>>());
        }

        [Test]
        public void returns_false_if_gived_type_was_the_same_but_arguments_was_other()
        {
            Assert.IsFalse(exec<Test1<int, int>, Test1<string, string>>());
        }

        [Test]
        public void returns_false_if_gived_type_was_other_and_arguments_was_other()
        {
            Assert.IsFalse(exec<Test1<int, int>, Test2<string, string>>());
        }

        [Test]
        public void returns_false_if_gived_type_was_same_but_arguments_had_another_order()
        {
            Assert.IsFalse(exec<Test1<int, string>, Test1<string, int>>());
        }
    }
}