using System;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class constructorparameterbytypefinder_findbytype_tests
    {

        IConstructorParameter exec<T>(params object[] instances)
        {
            ConstructorParameters constructorParameters = new ConstructorParameters();
            foreach (object instance in instances)
            {
                constructorParameters.Add(new ConstructorParameter() {Type = instance.GetType(), Value = instance});
            }

            IConstructorParameter result = new ConstructorParameterByTypeFinder().FindByType(constructorParameters, typeof(T));
            return result;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<int>(0));
        }

        [Test]
        public void returns_not_null_when_gived_parameters_was_good()
        {
            Assert.NotNull(exec<int>(0, ""));
        }

        [Test]
        public void returns_typeof_registerparameter()
        {
            Assert.IsTrue(exec<int>(0) is ConstructorParameter);
        }

        [Test]
        public void returns_type_is_assignable_of_iregisterparameters()
        {
            Assert.IsTrue(exec<int>(0) is IConstructorParameter);
        }

        [Test]
        public void returns_int_when_generic_param_is_int_and_gived_was_int()
        {
            Assert.IsTrue(exec<int>(0, 0f, 0d, "string", true).Value is int);
        }

        [Test]
        public void returns_string_when_generic_param_is_string_and_gived_was_string()
        {
            Assert.IsTrue(exec<string>(0, 0f, 0d, "string", true).Value is string);
        }

        [Test]
        public void returns_excepted_value_is_target_result_is_string()
        {
            string str = Guid.NewGuid().ToString();
            
            Assert.AreEqual(str, exec<string>(0, 0f, 0d, str, true).Value);
        }

        [Test]
        public void returns_first_if_is_many_match_types()
        {
            Assert.IsTrue((int) exec<int>(1, 2, 3).Value == 1);
            Assert.IsTrue((bool) exec<bool>(true, false, false, false).Value);
        }

        [Test]
        public void throws_invalidoperationexception_when_array_is_empty()
        {
            Assert.Throws<InvalidOperationException>(()=> exec<int>());
        }
    }
}