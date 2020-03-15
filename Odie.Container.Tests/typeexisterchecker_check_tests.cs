using System.Collections.Generic;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Container.Tests
{
    public class typeexisterchecker_check_tests
    {
        class Test1 : ITest1
        {
        }

        class Test2 : ITest2
        {
        }

        interface ITest1
        {
        }

        interface ITest2
        {
        }

        bool exec<T>()
        {
            ServiceGenerator generator =
                new ServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator(),new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())), new ServiceInfoGenerator());
            Service test1Service = generator.GenerateService(typeof(Test1));

            ServicesList list = new ServicesList();
            list.AddService(test1Service);

            TypeExisterChecker checker = new TypeExisterChecker(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker());
            return checker.Check(list, typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1>());
        }

        [Test]
        public void returns_true_if_gived_is_test1()
        {
            Assert.IsTrue(exec<Test1>());
        }

        [Test]
        public void returns_false_if_gived_is_test2()
        {
            Assert.IsFalse(exec<Test2>());
        }
        
        [Test]
        public void returns_true_if_gived_is_interface_of_test1()
        {
            Assert.IsTrue(exec<ITest1>());
        }

        [Test]
        public void returns_false_if_gived_is_interface_of_test2()
        {
            Assert.IsFalse(exec<ITest2>());
        }
    }
}