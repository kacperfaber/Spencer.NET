using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class constructorparametersgenerator_generateparameters_constructorinfo_constructorparameters_tests
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

        IParameter[] exec(int parameters, params object[] instances)
        {
            ConstructorInfo ctor = typeof(Test1).GetConstructors().SingleOrDefault(x => x.GetParameters().Length == parameters);

            ConstructorParameters constructorParameters = new ConstructorParameters();
            
            foreach (object instance in instances)
            {
                constructorParameters.Add(new ConstructorParameter() {Type = instance.GetType(), Value = instance});
            }

            IEnumerable<IParameter> generateParameters(ConstructorInfo info)
            {
                foreach (ParameterInfo parameterInfo in info.GetParameters())
                {
                    yield return new ParameterBuilder()
                        .AddType(parameterInfo.ParameterType)
                        .AddDefaultValue(parameterInfo.DefaultValue)
                        .HasDefaultValue(parameterInfo.HasDefaultValue)
                        .Build();
                }
            }

            TypedMemberValueProvider typedMemberValueProvider = new TypedMemberValueProvider();
            ConstructorParametersGenerator generator = new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),new ServiceHasConstructorParametersChecker());
            IEnumerable<IParameter> generatedParameters = generateParameters(ctor);

            foreach (IParameter parameter in generatedParameters)
            {
                Console.WriteLine($"{parameter.Type.FullName}:: {parameter.Value}");
            }

            IParameter[] result = generator.GenerateParameters(new Constructor() {Instance = ctor, Parameters = generatedParameters}, constructorParameters).ToArray();

            return result;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(3, 0, 5, 10));
        }

        [Test]
        public void returns_parameters_not_null()
        {
            IParameter[] parameters = exec(3, 0, 5, 10);

            foreach (IParameter parameter in parameters)
            {
                Assert.NotNull(parameter);                
            }
        }

        [Test]
        public void returns_parameters_values_not_null()
        {
            IParameter[] parameters = exec(3, 0, 5, 10);

            foreach (IParameter parameter in parameters)
            {
                Assert.NotNull(parameter.Value);                
            }
        }

        [TestCase(1, 5, 6)]
        [TestCase(0, 5, 10)]
        [TestCase(0, 0, 0)]
        [TestCase(100, 500, 250)]
        public void returns_gived_parameters_when_target_is_int_ctor(params object[] parameters)
        {
            IParameter[] result = exec(3, parameters);
            object[] values = Array.ConvertAll(result, x => x.Value);

            Assert.IsTrue(values.SequenceEqual(parameters));
        }

        [Test]
        public void returns_valid_parameters_if_gived_was_in_bad_order()
        {
            object[] objects = exec(2, new Lukasz(), new Kasia());

            object first = (objects.First() as Parameter).Value;
            object last = (objects.Last() as Parameter).Value;

            Assert.IsTrue(first.GetType() == typeof(Kasia)); // first type is KASIA :C
            Assert.IsTrue(last.GetType() == typeof(Lukasz));
        }

        [Test]
        public void returns_valid_parameters_sequence_if_gived_was_in_good_order()
        {
            object[] objects = exec(2, new Kasia(), new Lukasz());

            Assert.IsTrue((objects.First() as Parameter).Value.GetType() == typeof(Kasia));
            Assert.IsTrue((objects.Last() as Parameter).Value.GetType() == typeof(Lukasz));
        }
    }
}