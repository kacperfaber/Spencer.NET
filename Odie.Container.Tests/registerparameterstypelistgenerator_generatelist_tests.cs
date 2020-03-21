using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class registerparameterstypelistgenerator_generatelist_tests
    {

        IEnumerable<Type> exec(params object[] instances)
        {
            IRegisterParameters parameters = new RegisterParameters();
            foreach (object instance in instances)
            {
                parameters.Parameters.Add(new RegisterParameter()
                {
                    Type = instance.GetType(),
                    Value = instance
                });
            }

            return new RegisterParametersTypeListGenerator().GenerateList(parameters);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [TestCase(0, 1, 2)]
        [TestCase("", "", "")]
        [TestCase(50, 150, 500)]
        [TestCase(0f, 5f, 10f)]
        [TestCase(0d, 5d, 10d)]
        public void returns_excepted_items_lenght(params object[] instances)
        {
            Assert.IsTrue(instances.Count() == exec(instances).Count());
        }

        [TestCase(0, 1, 2)]
        [TestCase("", "", "")]
        [TestCase(50, 150, 500)]
        [TestCase(0f, 5f, 10f)]
        [TestCase(0d, 5d, 10d)]
        public void returns_sequence_equals_enumerable(params object[] instances)
        {
            Assert.IsTrue(exec(instances).SequenceEqual(Array.ConvertAll(instances, x => x.GetType())));
        }
    }
}