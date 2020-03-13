using System;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Container.Tests
{
    public class instancescreator_createinstance_tests
    {
        interface ITest1
        {
        }

        class Dep1 : ITest1
        {
        }

        class TestClass
        {
            public Dep1 test;
            
            public TestClass(Dep1 test1)
            {
                test = test1;
            }
        }

        class Resolver : IContainerResolver
        {
            public object Resolve(Type key)
            {
                if (key == typeof(Dep1))
                {
                    return new Dep1();
                }

                throw new ArgumentException();
            }

            public bool Has(Type key)
            {
                if (key == typeof(Dep1))
                {
                    return true;
                }

                return false;
            }
        }

        object exec<T>()
        {
            ServiceGenerator generator = new ServiceGenerator(new ServiceFlagsGenerator(new AttributesFinder()),
                new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator()));
            Service service = generator.GenerateService(typeof(T));

            InstancesCreator creator = new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(), new ValueTypeActivator(),
                    new TypeIsValueTypeChecker()));

            object instance = creator.CreateInstance(service.Flags, service.Registration.TargetType, new Resolver(), null);

            return instance;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_typeof_TestClass()
        {
            Assert.IsTrue(exec<TestClass>().GetType() == typeof(TestClass));
        }

        [Test]
        public void returns_TestClass_dot_test_not_null()
        {
            Assert.NotNull(((TestClass)exec<TestClass>()).test);
        }
    }
}