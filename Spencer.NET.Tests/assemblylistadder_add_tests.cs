using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class assemblylistadder_add_tests
    {
        AssemblyList exec(params Type[] assemblyTypes)
        {
            AssemblyList list = new AssemblyList();
            AssemblyListAdder adder = new AssemblyListAdder();

            foreach (Type assemblyType in assemblyTypes)
            {
                adder.Add(list, assemblyType.Assembly);
            }

            return list;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(GetType()));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(GetType()));
        }

        [TestCase(typeof(assemblylistadder_add_tests), typeof(ServiceResolver), typeof(object))]
        [TestCase(typeof(assemblylistadder_add_tests))]
        public void returns_params_types_len(params Type[] types)
        {
            int len = exec(types).GetAssemblies().Count();

            Assert.IsTrue(len == types.Count());
        }

        [TestCase(typeof(assemblylistadder_add_tests), typeof(assemblylistcontainschecker_contains_tests))]
        [TestCase(typeof(genericparametersprovider_provide_tests), typeof(registrationinterfacesfilter_filter_tests))]
        public void returns_two_if_gived_was_two_types(Type t1, Type t2)
        {
            AssemblyList list = exec(new List<Type>() {t1, t2}.ToArray());

            Assert.IsTrue(list.GetAssemblies().Count() == 2);
        }

        [Test]
        public void ret()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register(GetType());
        }
    }
}