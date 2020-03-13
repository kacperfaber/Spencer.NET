﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Container.Tests
{
    public class servicefinder_find_tests
    {
        interface ITest1
        {
        }

        interface ITest2
        {
        }

        class Test1 : ITest1
        {
        }

        class Test2 : ITest2
        {
        }

        Service exec<TKey>()
        {
            ServiceGenerator generator = new ServiceGenerator(new ServiceFlagsGenerator(new AttributesFinder()), new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator()));

            Service test1 = generator.GenerateService(typeof(Test1));
            Service test2 = generator.GenerateService(typeof(Test2));

            List<Service> services = new List<Service>() {test1, test2};
            
            ServiceFinder finder = new ServiceFinder();
            return finder.Find(services, typeof(TKey));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest1>());
        }

        [Test]
        public void returns_service_test1_if_gived_key_is_itest1()
        {
            Assert.AreEqual(typeof(Test1), exec<ITest1>().Registration.TargetType);
        }
        
        [Test]
        public void returns_service_test2_if_gived_key_is_itest2()
        {
            Assert.AreEqual(typeof(Test2), exec<ITest2>().Registration.TargetType);
        }
    }
}