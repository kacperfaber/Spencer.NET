using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class registrationinterfacesfilter_filter_tests
    {
        interface ITest1
        {
        }

        interface ITest2
        {
        }

        interface IGeneric<T1, T2>
        {
            
        }

        class TestClass : ITest1, ITest2, IDisposable, IGeneric<int, int>
        {
            public void Dispose()
            {
            }
        }

        List<Type> exec()
        {
            RegistrationInterfacesFilter filter = new RegistrationInterfacesFilter(new NamespaceInterfaceValidator());
            return filter.Filter(typeof(TestClass).GetInterfaces()).ToList();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_excepted_excepted_result_len_if_target_is_TestClass()
        {
            List<Type> res = exec();

            foreach (Type type in res)
            {
                Console.WriteLine("has " + type.Name);
            }
            
            Assert.IsTrue(res.Count == 3);
        }

        [Test]
        public void returns_not_contains_IDisposable()
        {
            Assert.IsFalse(exec().Contains(typeof(IDisposable)));
        }
    }
}