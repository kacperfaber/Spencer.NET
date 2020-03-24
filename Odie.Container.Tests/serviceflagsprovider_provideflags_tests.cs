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

            [Factory]
            public static TestClass FactoryMethod()
            {
                return null;
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
            int count = exec<TestClass>().Count();

            Assert.IsTrue(count == 5);
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
        public void returns_servicefactory_attribute()
        {
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory));
        }

        [Test]
        public void returns_servicefactory_parent_not_null()
        {
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Parent);
        }

        [Test]
        public void returns_servicefactory_parent_is_methodinfo()
        {
            bool b = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Parent is MethodInfo;
            Assert.IsTrue(b);
        }

        [Test]
        public void returns_servicefactory_parent_membertype_equals_to_method()
        {
            MemberTypes type = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Parent.MemberType;
            Assert.IsTrue(type == MemberTypes.Method);
        }

        [Test]
        public void returns_servicefactory_cast_to_methodinfo_does_not_throws()
        {
            MemberInfo parent = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Parent;
            
            Assert.DoesNotThrow(() =>
            {
                _ = (MethodInfo) parent;
            });
        }

        [Test]
        public void return_servicefactory_methodinfo_returntype_equals_to_TestClass()
        {
            MethodInfo method = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Parent as MethodInfo;
            
            Assert.IsTrue(method.ReturnType == typeof(TestClass));
        }

        [Test]
        public void return_servicefactory_methodinfo_isstatic_returns_true()
        {
            MethodInfo method = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Parent as MethodInfo;
            
            Assert.IsTrue(method.IsStatic);
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