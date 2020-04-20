using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class factoriesbytypefilter_filter_tests
    {
        interface ITest
        {
        }

        class Test1 : ITest
        {
        }

        class Test2 : ITest
        {
        }

        class Test3
        {
        }

        class Test4
        {
        }

        List<IFactory> exec<T>()
        {
            List<Factory> factory = new List<Factory>
            {
                new Factory() {ResultType = typeof(void)},
                new Factory() {ResultType = typeof(int)},
                new Factory() {ResultType = typeof(bool)},
                new Factory() {ResultType = typeof(Test1)},
                new Factory() {ResultType = typeof(Test2)},
                new Factory() {ResultType = typeof(Test3)},
                new Factory() {ResultType = typeof(Test4)}
            };

            FactoriesByTypeFilter filter = new FactoriesByTypeFilter(new AssignableChecker());
            return filter.Filter(typeof(T), factory).ToList();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest>());
        }

        [Test]
        public void returns_excepted_len_if_gived_was_itest()
        {
            Assert.IsTrue(exec<ITest>().Count() == 2);
        }

        [Test]
        public void returns_excepted_len_if_gived_was_test3()
        {
            Assert.IsTrue(exec<Test3>().Count() == 1);
        }

        [Test]
        public void returns_list_contains_typeof_Test1_and_Test2_if_gived_was_ITest()
        {
            List<IFactory> result = exec<ITest>();
            
            Assert.NotNull(result.SingleOrDefault(x => x.ResultType == typeof(Test1)));
            Assert.NotNull(result.SingleOrDefault(x => x.ResultType == typeof(Test2)));
        }

        [Test]
        public void returns_list_contains_typeof_Test3_if_gived_Test3()
        {
            Assert.AreEqual(exec<Test3>().First().ResultType, typeof(Test3));
        }
        
        [Test]
        public void returns_list_contains_typeof_Test4_if_gived_Test4()
        {
            Assert.AreEqual(exec<Test4>().First().ResultType, typeof(Test4));
        }

        [Test]
        public void returns_not_contains_Valuetype_if_gived_is_object()
        {
            Assert.Null(exec<object>().SingleOrDefault(x => typeof(ValueType).IsAssignableFrom(x.ResultType)));
        }

        [Test]
        public void returns_not_contains_typeof_void()
        {
            Assert.Null(exec<object>().SingleOrDefault(x => x.ResultType == typeof(void)));
        }
    }
}