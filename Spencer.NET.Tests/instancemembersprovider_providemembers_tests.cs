using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class instancemembersprovider_providemembers_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
            [Instance]
            public static TestClass Instance { get; set; }
        }

        IEnumerable<IMember> exec<T>()
        {
            ServiceFlagsProvider provider = new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator()));
            ServiceFlags flags = provider.ProvideFlags(typeof(T));

            IEnumerable<IMember> members = new InstanceMembersProvider().ProvideMembers(flags);

            return members;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_single_element_if_target_was_TestClass()
        {
            Assert.IsTrue(exec<TestClass>().Count() == 1);   
        }

        [Test]
        public void returns_member_name_equals_to_Instance()
        {
            IMember member = exec<TestClass>().First();
            
            Assert.AreEqual("Instance", member.Instance.Name);
        }

        [Test]
        public void returns_not_null_first_item()
        {
            Assert.NotNull(exec<TestClass>().First());
        }
    }
}