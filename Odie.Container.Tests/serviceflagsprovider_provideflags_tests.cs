using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic;
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

            [Inject]
            public string Name { get; set; }

            [Inject]
            public string Email;
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
            int count = exec<TestClass>().Count();

            Assert.IsTrue(count == 4);
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

        [Test]
        public void returns_object_getflags_inject_returns_count_2()
        {
            ServiceFlags flags = exec<TestClass>();
            IEnumerable<ServiceFlag> injects = flags.GetFlags(ServiceFlagConstants.Inject);

            Assert.IsTrue(injects.Count() == 2);
        }

        [Test]
        public void returns_object_getflags_inject_returns_not_null_parent()
        {
            ServiceFlags flags = exec<TestClass>();
            IEnumerable<ServiceFlag> injects = flags.GetFlags(ServiceFlagConstants.Inject);

            foreach (ServiceFlag serviceFlag in injects)
            {
                Assert.NotNull(serviceFlag.Parent);
            }
        }

        [Test]
        public void returns_object_getflags_inject_returns_propertyinfo_name_equals_to_Name()
        {
            ServiceFlags flags = exec<TestClass>();
            IEnumerable<ServiceFlag> injects = flags.GetFlags(ServiceFlagConstants.Inject);
            ServiceFlag inject = injects.First(x => x.Parent.MemberType == MemberTypes.Property);
            bool result = inject.Parent.Name == "Name";
            
            Assert.IsTrue(result);
        }
    }
}