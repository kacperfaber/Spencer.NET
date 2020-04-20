using System;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class typeimplementsinterfacevalidator_validate_tests
    {

        bool exec(Type i, Type c)
        {
            return new TypeImplementsInterfaceValidator().Validate(c, i);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(typeof(object), typeof(object)));
        }

        [TestCase(typeof(INamespaceInterfaceValidator), typeof(NamespaceInterfaceValidator))]
        [TestCase(typeof(IAlwaysNewChecker), typeof(AlwaysNewChecker))]
        [TestCase(typeof(IService), typeof(Service))]
        [TestCase(typeof(IServiceFinder), typeof(ServiceFinder))]
        public void returns_true_when_class_implements_interface(Type @interface, Type @class)
        {
            Assert.IsTrue(exec(@interface, @class));
        }
        
        [TestCase(typeof(INamespaceInterfaceValidator), typeof(NamespaceInterfaceValidator))]
        [TestCase(typeof(IAlwaysNewChecker), typeof(AlwaysNewChecker))]
        [TestCase(typeof(IService), typeof(Service))]
        [TestCase(typeof(IServiceFinder), typeof(ServiceFinder))]
        public void returns_false_when_class_not_implements_interface(Type @class, Type @interface)
        {
            Assert.IsFalse(exec(@interface, @class));
        }
    }
}