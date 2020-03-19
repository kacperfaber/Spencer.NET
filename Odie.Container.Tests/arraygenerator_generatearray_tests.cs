using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class arraygenerator_generatearray_tests
    {
        object exec<T>()
        {
            return new ArrayGenerator().GenerateArray(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<int>());
        }

        [Test]
        public void returns_type_is_array()
        {
            Assert.IsTrue(exec<int>().GetType().IsArray);
        }

        [Test]
        public void returns_value_can_be_cast_to_array_with_excepted_type()
        {
            Assert.DoesNotThrow(() =>
            {
                int[] ints = (int[]) exec<int>();
            });
        }

        [Test]
        public void returns_value_casted_to_int_array_has_lenght_equals_to_0()
        {
            int[] ints = (int[]) exec<int>();
            
            Assert.IsTrue(ints.Length == 0);
        }
    }
}