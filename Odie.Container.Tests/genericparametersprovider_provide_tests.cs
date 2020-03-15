using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class genericparametersprovider_provide_tests
    {
        class Test1<T1, T2>
        {
        }

        class Test2
        {
        }

        IServiceGenericRegistration exec<T>()
        {
            ServiceServiceGenericRegistrationGenerator generator = new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker());
            return generator.Generate(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test2>());
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<Test1<object, object>>());
        }

        [Test]
        public void returns_hasgenericparameters_true_if_gived_is_test1()
        {
            Assert.IsTrue(exec<Test1<object, int>>().HasGenericParameters);
        }
        
        [Test]
        public void returns_hasgenericparameters_false_if_gived_is_test2()
        {
            Assert.IsFalse(exec<Test2>().HasGenericParameters);
        }

        [Test]
        public void returns_genericparameters_count_2_if_gived_is_test1()
        {
            Assert.IsTrue(exec<Test1<object, int>>().GenericParameters.Count == 2);
        }
        
        [Test]
        public void returns_genericparameters_count_0_if_gived_is_test2()
        {
            Assert.IsTrue(exec<Test2>().GenericParameters.Count == 0);
        }
    }
}