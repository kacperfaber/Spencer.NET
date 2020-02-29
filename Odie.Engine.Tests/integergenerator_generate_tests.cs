using System;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Engine.Tests
{
    public class integergenerator_generate_tests
    {
        object execute(int min, int max, out Type type)
        {
            IntegerParameters parameters = new IntegerParameters() {Max = max, Min = min};

            return new IntegerGenerator(new RandomGenerator(), new TypeChanger()).Generate(parameters, parameters.GetType(), typeof(int), out type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => { execute(0, 100, out Type type); });
        }

        [TestCase(200, 0, 100)]
        [TestCase(200, -100, 100)]
        [TestCase(200, 0,1)]
        public void dont_returns_out_of_specified_range_ints(int times, int min, int max)
        {
            for (int i = 0; i < times; i++)
            {
                object res = execute(min, max, out Type type);
                
                Console.Write((int)res);
                Assert.IsTrue(((int)res) <= max && (int)res >= min);
                Console.Write(" ok\n");
            }
        }

        [Test]
        public void out_parameters_valuetype_is_int()
        {
            execute(0, 1, out Type type);
            
            Assert.IsTrue(typeof(int) == type);
        }
    }
}