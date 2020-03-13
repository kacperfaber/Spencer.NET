using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class parameterinfohasdefaultvaluechecker_check_tests
    {
        class test
        {
            public void hello(int x, int y = 0)
            {
            }
        }

        bool exec(string name = "x")
        {
            MethodInfo[] methods = typeof(test).GetMethods();
            ParameterInfo[] parameters = methods.Single(x => x.ReturnType == typeof(void) && x.Name == "hello").GetParameters();
            
            ParameterInfoHasDefaultValueChecker checker = new ParameterInfoHasDefaultValueChecker();
            return checker.Check(parameters.Single(x => x.Name == name));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_true_if_gave_parametername_is_y()
        {
            Assert.IsTrue(exec("y"));
        }

        [Test]
        public void returns_false_if_gave_parametername_is_x()
        {
            Assert.IsFalse(exec("x"));
        }
    }
}