﻿using System;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class memberdeclarationtypeprovider_providedeclarationtype_tests
    {
        class TestClass
        {
            public TestClass()
            {
                Float = 5;
            }

            public static string Hello() => "hello";

            public static int World() => 0;

            public static bool Boolean { get; set; }

            public static float Float = 5;
        }

        Type exec(string name)
        {
            return new MemberDeclarationTypeProvider()
                .ProvideDeclarartionType(typeof(TestClass).GetMembers().Where(x => x.Name.ToLower() == name.ToLower()).First());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec("hello"));
        }

        [Test]
        public void returns_string_if_target_was_hello()
        {
            Assert.IsTrue(exec("hello") == typeof(string));
        }

        [Test]
        public void returns_int_if_target_was_world()
        {
            Assert.IsTrue(exec("world") == typeof(int));
        }

        [Test]
        public void returns_bool_if_target_was_boolean()
        {
            Assert.IsTrue(exec("boolean") == typeof(bool));
        }

        [Test]
        public void returns_float_if_target_was_float()
        {
            Assert.IsTrue(exec("float") == typeof(float));
        }
    }
}