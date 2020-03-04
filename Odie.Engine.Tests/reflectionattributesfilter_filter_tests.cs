using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Engine.Tests
{
    public class reflectionattributesfilter_filter_tests
    {
        class MyAttribute : Attribute
        {
        }

        [My]
        [Author("KACPER FABER")]
        class Test
        {
        }

        class ns_filter : IFilter<Attribute>
        {
            public IEnumerable<Attribute> Filter(IEnumerable<Attribute> enumerable)
            {
                Console.WriteLine("I AM GOIND!!!");
                
                foreach (Attribute attribute in enumerable)
                {
                    string? fullName = attribute.GetType().FullName;
                    if (fullName.Contains("Tests"))
                    {
                        yield return attribute;
                    }
                }
            }
        }

        class author_filter : IFilter<Attribute>
        {
            public IEnumerable<Attribute> Filter(IEnumerable<Attribute> enumerable)
            {
                foreach (Attribute attribute in enumerable)
                {
                    if (attribute is AuthorAttribute) continue;
                    else yield return attribute;
                }
            }
        }

        IEnumerable<Attribute> exec<T>(params IFilter<Attribute>[] filters)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(typeof(T));

            ReflectionAttributesFilter filter = new ReflectionAttributesFilter();
            filter.Filters.AddRange(filters);

            return filter.Filter(attributes);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test>());
        }

        [Test]
        public void returns_2_attributes_when_applied_is_any_filter()
        {
            int len = exec<Test>().Count();
            Console.WriteLine(len);

            Assert.IsTrue(len == 2);
        }

        [Test]
        public void returns_1_attributes_if_ns_filter_is_applied()
        {
            int len = exec<Test>(new ns_filter()).Count();

            Console.WriteLine(len);
            
            Assert.IsTrue(len == 1);
        }
    }
}