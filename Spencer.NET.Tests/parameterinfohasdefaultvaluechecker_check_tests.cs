using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Spencer.NET;

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
            ParameterInfo parameterInfo = parameters.Single(x => x.Name == name);
            Parameter parameter = new ParameterBuilder()
                .AddType(parameterInfo.ParameterType)
                .AddDefaultValue(parameterInfo.DefaultValue)
                .HasDefaultValue(parameterInfo.HasDefaultValue)
                .Build();

            ParameterHasDefaultValueChecker checker = new ParameterHasDefaultValueChecker();
            
            return checker.Check(parameter);
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