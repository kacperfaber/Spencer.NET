﻿using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class resolveparametersgenerator_generateparameters_tests
    {
        class Test1
        {
        }

        class Test2
        {
        }

        class Test3
        {
        }

        IResolveParameters exec(params object[] parameters)
        {
            return new ResolveParametersGenerator(new TypeGetter()).GenerateParameters(parameters);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_typeof_ResolveParameters()
        {
            Assert.IsTrue(exec().GetType() == typeof(ResolveParameters));
        }

        [Test]
        public void returns_excepted_dictionary_keys_len()
        {
            Assert.IsTrue(exec(new Test1(), new Test2()).Parameters.Count == 2);
        }

        [Test]
        public void returns_parameters_not_null()
        {
            Assert.NotNull(exec(new Test1()).Parameters);
        }

        [Test]
        public void returns_parameters_instanceof_ResolveParameter()
        {
            foreach (IResolveParameter parameter in exec(new Test1(), new Test2()).Parameters)
            {
                Assert.IsTrue(parameter.GetType() == typeof(ResolveParameter));
            }
        }

        [Test]
        public void returns_first_excepted_data()
        {
            Test1 test = new Test1();
            IResolveParameter p = exec(test, new Test2()).Parameters.First();
            
            Assert.IsTrue(p.Type == typeof(Test1));
            Assert.AreEqual(test, p.Value);
        }
    }
}