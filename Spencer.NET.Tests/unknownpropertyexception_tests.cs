using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class unknownpropertyexception_tests
    {
        [Test]
        public void is_Exception()
        {
            Assert.IsTrue(typeof(Exception).IsAssignableFrom(typeof(UnknownPropertyException)));
        }

        [Test]
        public void has_no_empty_constructor()
        {
            Assert.Null(typeof(UnknownPropertyException).GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0));
        }

        [Test]
        public void has_constructor_with_single_string_parameter()
        {
            Assert.NotNull(typeof(UnknownPropertyException).GetConstructors().Where(x => x.GetParameters().FirstOrDefault().ParameterType == typeof(string)));
        }

        [Test]
        public void Exception_Message_is_not_null_after_initializing()
        {
            UnknownPropertyException exception = new UnknownPropertyException("");
            
            Assert.NotNull(exception.Message);
        }

        [Test]
        public void Exception_Message_contains_string_gived_in_constructor()
        {
            string param = Guid.NewGuid().ToString();
            UnknownPropertyException exception = new UnknownPropertyException(param);
            
            Assert.IsTrue(exception.Message.Contains(param));
        }

        [Test]
        public void Exception_Message_passing_to_pattern()
        {
            string param = Guid.NewGuid().ToString();
            UnknownPropertyException exception = new UnknownPropertyException(param);
            string pattern = @$"^Could not specify {param}.$";
            
            Assert.IsTrue(Regex.IsMatch(exception.Message, pattern));
        }

        [Test]
        public void is_not_Obsolete()
        {
            Assert.Null(typeof(UnknownPropertyException).GetCustomAttribute(typeof(ObsoleteAttribute)));
        }
    }
}