using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class parameterinfodefaultvalueprovider_provide_tests
    {
        class TestClass
        {
            public TestClass(int x = 1, int y = 2, int z = 3)
            {
            }
        }

        object exec(string name)
        {
            ConstructorInfo ctor = typeof(TestClass).GetConstructors().First();
            ParameterInfo p = ctor.GetParameters().SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
            IParameter parameter = new ParameterBuilder()
                .AddType(p.ParameterType)
                .AddValue(null)
                .AddDefaultValue(p.HasDefaultValue)
                .AddDefaultValue(p.DefaultValue)
                .Build();
            ParameterDefaultValueProvider provider = new ParameterDefaultValueProvider();
            return provider.Provide(parameter);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec("x"));
        }

        [Test]
        public void returns_instanceof_int()
        {
            Assert.IsTrue(exec("z") is int);
        }

        [Test]
        public void returns_1_if_parameter_name_is_x()
        {
            Assert.IsTrue((int) exec("x") == 1);
        }

        [Test]
        public void returns_2_if_parameter_name_is_y()
        {
            Assert.IsTrue((int) exec("y") == 2);
        }

        [Test]
        public void returns_3_if_parameter_name_is_z()
        {
            Assert.IsTrue((int) exec("z") == 3);
        }
    }
}