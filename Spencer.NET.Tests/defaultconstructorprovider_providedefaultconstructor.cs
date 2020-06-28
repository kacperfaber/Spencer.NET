using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class defaultconstructorprovider_providedefaultconstructor
    {
        IConstructor exec(params ServiceRegistrationFlag[] flags)
        {
            return new DefaultConstructorProvider().ProvideDefaultConstructor(flags);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Constructor instance = new Constructor();
            ServiceRegistrationFlag flag = new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, instance);

            Assert.DoesNotThrow(() => exec(flag));
        }

        [Test]
        public void returns_instance_equal_to_gived_in_flag_named_DefaultConstructor()
        {
            Constructor instance = new Constructor();
            ServiceRegistrationFlag flag = new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, instance);

            Assert.AreEqual(instance, exec(flag));
        }

        [Test]
        public void throws_exception_if_gived_was_two_same_flags()
        {
            Constructor instance = new Constructor();
            ServiceRegistrationFlag flag = new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, instance);

            Assert.That(() => exec(flag, flag), Throws.Exception);
        }

        [Test]
        public void throws_exceptions_if_gived_was_two_flags_with_same_names()
        {
            ServiceRegistrationFlag flag = new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, new Constructor());
            ServiceRegistrationFlag flag2 = new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, new Constructor());
            
            Assert.That(() => exec(flag, flag2), Throws.Exception);
        }

        [TestCase(typeof(object))]
        [TestCase(typeof(float))]
        [TestCase(typeof(bool))]
        [TestCase(typeof(int))]
        public void throws_exceptions_if_target_value_type_is_not_assignable_to_IConstructor(Type valueType)
        {
            object instance = Activator.CreateInstance(valueType);
            ServiceRegistrationFlag flag = new ServiceRegistrationFlag(RegistrationFlagConstants.DefaultConstructor, instance);

            Assert.That(() => exec(flag), Throws.Exception);
        }
    }
}