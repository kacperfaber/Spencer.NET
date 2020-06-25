using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class factorytypegenerator_generate_tests
    {
        class TestClass
        {
#pragma warning disable
            public static string Hello { get; set; }

            public static int World;

            public static int Create()
            {
                return 0;
            }
#pragma warning restore
        }

        int exec(MemberInfo member)
        {
            IMember m = new MemberGenerator(new MemberFlagsGenerator()).GenerateMember(member);
            return new FactoryTypeGenerator().Generate(m);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(typeof(TestClass).GetMembers().First(x => x.Name == "Hello")));
        }

        [Test]
        public void returns_equals_to_factorytype_staticmethod_if_target_was_method()
        {
            int i = exec(typeof(TestClass).GetMembers().First(x => x.Name == "Create"));
            
            Assert.IsTrue(i == FactoryType.StaticMethod);
        }
    }
}