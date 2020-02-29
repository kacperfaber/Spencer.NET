using NUnit.Framework;

namespace Odie.Commons.Tests
{
    public class typechangervalidator_validate_generic_tests
    {
        class BaseClass
        {
        }

        class MidClass : BaseClass
        {
        }

        class TargetClass : MidClass
        {
        }

        bool exec<TFrom, TTo>()
        {
            return new TypeChangerValidator()
                .CanChange<TFrom, TTo>();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<BaseClass, TargetClass>());
        }

        [Test]
        public void returns_true_if_from_is_midclass_and_to_is_baseclass()
        {
            Assert.IsTrue(exec<MidClass, BaseClass>());
        }

        [Test]
        public void returns_true_if_from_is_targetclass_and_to_is_baseclass()
        {
            Assert.IsTrue(exec<TargetClass, BaseClass>());
        }

        [Test]
        public void returns_false_if_from_is_baseclass_and_to_is_targetclass()
        {
            Assert.IsFalse(exec<BaseClass,TargetClass>());
        }
        
        [Test]
        public void returns_false_if_from_is_baseclass_and_to_is_midclass()
        {
            Assert.IsFalse(exec<BaseClass,MidClass>());
        }
    }
}