﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class serviceflagsprovider_provideflags_tests
    {
        [SingleInstance]
        class TestClass
        {
#pragma warning disable
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

            [Instance]
            public static TestClass FieldInstance;

            [Instance]
            public static TestClass PropertyInstance { get; set; }
#pragma warning restore
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
            ServiceFlagsProvider provider = new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator()));
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

            Assert.IsTrue(count == 7);
        }

        [Test]
        public void returns_serviceconstructor_flag_if_gived_is_TestClass()
        {
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceCtor));
        }

        [Test]
        public void returns_serviceconstructor_flag_parent_membertype_equals_to_constructor()
        {
            Assert.IsTrue(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceCtor).Member.Instance.MemberType ==
                          MemberTypes.Constructor);
        }

        [Test]
        public void returns_serviceconstructor_flag_parent_parameters_lenght_equals_to_1()
        {
            Assert.IsTrue(
                (exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceCtor).Member.Instance as ConstructorInfo).GetParameters()
                .Count() == 1);
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
            Assert.NotNull(exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Member);
        }

        [Test]
        public void returns_servicefactory_parent_is_methodinfo()
        {
            bool b = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Member.Instance is MethodInfo;
            Assert.IsTrue(b);
        }

        [Test]
        public void returns_servicefactory_parent_membertype_equals_to_method()
        {
            MemberTypes memberFlag = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Member.Instance.MemberType;
            Assert.IsTrue(memberFlag == MemberTypes.Method);
        }

        [Test]
        public void returns_servicefactory_cast_to_methodinfo_does_not_throws()
        {
            MemberInfo parent = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Member.Instance;

            Assert.DoesNotThrow(() => { _ = (MethodInfo) parent; });
        }

        [Test]
        public void return_servicefactory_methodinfo_returntype_equals_to_TestClass()
        {
            MethodInfo method = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Member.Instance as MethodInfo;

            Assert.IsTrue(method.ReturnType == typeof(TestClass));
        }

        [Test]
        public void return_servicefactory_methodinfo_isstatic_returns_true()
        {
            MethodInfo method = exec<TestClass>().SingleOrDefault(x => x.Name == ServiceFlagConstants.ServiceFactory).Member.Instance as MethodInfo;

            Assert.IsTrue(method.IsStatic);
        }

        [Test]
        public void returns_object_getflags_inject_returns_not_null_parent()
        {
            ServiceFlags flags = exec<TestClass>();
            IEnumerable<ServiceFlag> injects = flags.GetFlags(ServiceFlagConstants.Inject);

            foreach (ServiceFlag serviceFlag in injects)
            {
                Assert.NotNull(serviceFlag.Member);
            }
        }

        [Test]
        public void returns_object_getflags_inject_returns_propertyinfo_name_equals_to_Name()
        {
            ServiceFlags flags = exec<TestClass>();
            IEnumerable<ServiceFlag> injects = flags.GetFlags(ServiceFlagConstants.Inject);
            ServiceFlag inject = injects.First(x => x.Member.Instance.MemberType == MemberTypes.Property);
            bool result = inject.Member.Instance.Name == "Name";

            Assert.IsTrue(result);
        }

        [Test]
        public void returns_contains_instance_flag()
        {
            Assert.NotNull(exec<TestClass>().FirstOrDefault(x => x.Name == ServiceFlagConstants.Instance));
        }

        [Test]
        public void returns_2_instance_flags()
        {
            IEnumerable<ServiceFlag> flags = exec<TestClass>().Where(x => x.Name == ServiceFlagConstants.Instance);

            Assert.IsTrue(flags.Count() == 2);
        }

        [Test]
        public void returns_one_property_instance_flag()
        {
            ServiceFlag flag = exec<TestClass>().Where(x => x.Name == ServiceFlagConstants.Instance)
                .SingleOrDefault(x => x.Member.MemberFlags.Is(MemberFlag.Property));

            Assert.NotNull(flag);
        }
        
        [Test]
        public void returns_one_field_instance_flag()
        {
            ServiceFlag flag = exec<TestClass>().Where(x => x.Name == ServiceFlagConstants.Instance)
                .SingleOrDefault(x => x.Member.MemberFlags.Is(MemberFlag.Field));

            Assert.NotNull(flag);
        }
    }
}