using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class serviceflagsprovider_provideflags_tests
    {
        [SingleInstance]
        class TestClass
        {
            [ServiceConstructor]
            public TestClass(int x = 0)
            {
            }
        }

        class Test2
        {
        }

        [MultiInstance]
        class Test3
        {
        }

        ServiceFlags exec<T>()
        {
            ServiceFlagsProvider provider = new ServiceFlagsProvider(new AttributesFinder());
            return provider.ProvideFlags(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_excepted_flags_count()
        {
            Assert.IsTrue(exec<TestClass>().Count() == 2);
        }

        [Test]
        public void returns_serviceconstructor_flag_if_gived_is_TestClass()
        {
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceCtor));
        }

        [Test]
        public void returns_serviceconstructor_flag_parent_membertype_equals_to_constructor()
        {
            Assert.IsTrue(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceCtor).Parent.MemberType == MemberTypes.Constructor);
        }

        [Test]
        public void returns_serviceconstructor_flag_parent_parameters_lenght_equals_to_1()
        {
            Assert.IsTrue(
                (exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceCtor).Parent as ConstructorInfo).GetParameters().Count() == 1);
        }

        [Test]
        public void returns_singleinstance_if_gived_instanceattr_is_singleinstance()
        {
            Assert.IsTrue(exec<TestClass>().HasFlag(ServiceFlagConstants.SingleInstance));
        }

        [Test]
        public void returns_multiinstance_flag_if_gived_instance_attribute_is_multiinstance()
        {
            Assert.IsTrue(exec<Test3>().HasFlag(ServiceFlagConstants.MultiInstance));
        }
    }
}