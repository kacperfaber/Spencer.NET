using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Container.Tests
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

        object[] exec(int parameters, params object[] instances)
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
            
            ParameterValueProvider parameterValueProvider = new ParameterValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(), new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new ParameterHasDefaultValueChecker(), new ParameterDefaultValueProvider());
            ConstructorParametersGenerator generator = new ConstructorParametersGenerator(parameterValueProvider,new ConstructorParameterByTypeFinder());
            object[] result = generator.GenerateParameters(new Constructor() {Instance = ctor, Parameters = generateParameters(ctor)}, constructorParameters).ToArray();

            return result;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(3, 0, 5, 10));
        }

        [TestCase(1, 5, 6)]
        [TestCase(0, 5, 10)]
        [TestCase(0, 0, 0)]
        [TestCase(100, 500, 250)]
        public void returns_gived_parameters_when_target_is_int_ctor(params object[] parameters)
        {
            object[] result = exec(3, parameters);

            bool equals = result.SequenceEqual(parameters);

            Assert.IsTrue(equals);
        }

        [Test]
        public void returns_valid_parameters_if_gived_was_in_bad_order()
        {
            object[] objects = exec(2, new Lukasz(), new Kasia());

            Assert.IsTrue(objects.First().GetType() == typeof(Kasia));
            Assert.IsTrue(objects.Last().GetType() == typeof(Lukasz));
        }

        [Test]
        public void returns_valid_parameters_sequence_if_gived_was_in_good_order()
        {
            object[] objects = exec(2, new Kasia(), new Lukasz());

            Assert.IsTrue(objects.First().GetType() == typeof(Kasia));
            Assert.IsTrue(objects.Last().GetType() == typeof(Lukasz));
        }
    }
}