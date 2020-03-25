using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class constructorprovider_provideconstructor_tests
    {
        class TestClass
        {
            [ServiceConstructor]
            public TestClass(int x = 0)
            {
            }

            public TestClass()
            {
            }
        }

        class Test2
        {
        }

        class Test3
        {
            Test3()
            {
            }
        }

        ConstructorInfo exec<T>()
        {
            Type @class = typeof(T);
            ServiceFlagsGenerator flagsGenerator =
                new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver());

            ServiceFlags flags = flagsGenerator.GenerateFlags(@class);

            ConstructorProvider provider = new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(), new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator())));

            return provider.ProvideConstructor(@class, flags).Instance;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_not_null_result()
        {
            Assert.NotNull(exec<TestClass>());
        }

        [Test]
        public void returns_constructor_with_int_x_parameter_if_gived_type_is_testclass()
        {
            ConstructorInfo exceptedCtor = typeof(TestClass).GetConstructors().SingleOrDefault(x => x.GetParameters().Length > 0);
            ConstructorInfo result = exec<TestClass>();

            Assert.AreEqual(exceptedCtor, result);
        }

        [Test]
        public void returns_constructor_with_empty_parameters_if_target_is_test2()
        {
            Assert.IsTrue(exec<Test2>().GetParameters().Length == 0);
        }

        [Test]
        public void throws_exception_if_constructor_is_private()
        {
            Assert.That(exec<Test3>, Throws.Exception);
        }
    }
}