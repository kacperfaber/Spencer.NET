using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class constructorparametersgenerator_generateparameters_constructorinfo_registerparameters_tests
    {
        class Kasia
        {
        }

        class Basia
        {
        }

        class Zenek
        {
        }

        class Lukasz
        {
        }

        class Test1
        {
            public Test1(Kasia kasia, Lukasz lukasz)
            {
            }

            public Test1(int x, int y, int z)
            {
            }
        }

        object[] exec(int parameters, params object[] instances)
        {
            ConstructorInfo ctor = typeof(Test1).GetConstructors().SingleOrDefault(x => x.GetParameters().Length == parameters);

            RegisterParameters registerParameters = new RegisterParameters();
            foreach (object instance in instances)
            {
                registerParameters.Add(new RegisterParameter() {Type = instance.GetType(), Value = instance});
            }

            ConstructorParametersGenerator generator = new ConstructorParametersGenerator(null, null, null, null);
            return generator.GenerateParameters(ctor, registerParameters).ToArray();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(3, 0, 5, 10));
        }

        [TestCase(1, 5, 6)]
        [TestCase(0, 5, 10)]
        [TestCase(0, 0 ,0)]
        [TestCase(100, 500, 250)]
        public void returns_gived_parameters_when_target_is_int_ctor(params object[] parameters)
        {
            object[] result = exec(3, parameters);

            bool equals = result.SequenceEqual(parameters);
            
            Assert.IsTrue(equals);
        }
        
        // TODO end tests.
    }
}