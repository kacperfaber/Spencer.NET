using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class assemblylistcontainschecker_contains_tests
    {
        bool exec(Type t)
        {
            AssemblyList list = new AssemblyList();
            list.AddAssembly(GetType().Assembly);

            AssemblyListContainsChecker checker = new AssemblyListContainsChecker();
            return checker.Contains(list, t.Assembly);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(typeof(assemblylistcontainschecker_contains_tests)));
        }

        [TestCase(typeof(assemblylistcontainschecker_contains_tests))]
        [TestCase(typeof(constructorprovider_provideconstructor_tests))]
        [TestCase(typeof(defaultconstructorprovider_providedefaultconstructor_tests))]
        public void returns_true_if_gived_type_is_container_tests_assembly(Type t)
        {
            Assert.IsTrue(exec(t));
        }

        [TestCase(typeof(AssemblyListContainsChecker))]
        [TestCase(typeof(ConstructorProvider))]
        [TestCase(typeof(ServiceFlagsGenerator))]
        public void returns_false_if_gived_type_is_container_assembly(Type t)
        {
            Assert.IsFalse(exec(t));
        }
    }
}