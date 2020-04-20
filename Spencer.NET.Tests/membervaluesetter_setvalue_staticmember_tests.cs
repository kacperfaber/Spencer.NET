using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class membervaluesetter_setvalue_staticmember_tests
    {
        class TestClass
        {
            public static object Field;
            public static object Property { get; set; }
        }
        
        void exec(string name, object value)
        {
            MemberInfo memberInfo = typeof(TestClass).GetMembers().Single(x => x.Name == name);
            IMember member = new MemberGenerator(new MemberFlagsGenerator()).GenerateMember(memberInfo);
            
            new MemberValueSetter().SetValue(member, value);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec("Field", 5));
        }
    }
}