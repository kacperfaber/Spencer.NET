using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Odie.Reflections.Tests
{
    public class reflectionattributesfilter_filter_tests
    {
        private const string AuthorName = "KACPER FABER";
        
        class MyAttribute : Attribute
        {
        }

        [My]
        [Author(AuthorName)]
        class Test
        {
        }

        class ns_filter : IFilter<Attribute>
        {
            public IEnumerable<Attribute> Filter(IEnumerable<Attribute> enumerable)
            {
                foreach (Attribute attribute in enumerable)
                {
                    if (attribute.GetType().FullName.Contains("Odie"))
                        yield return attribute;
                }
            }
        }

        class author_filter : IFilter<Attribute>
        {
            public IEnumerable<Attribute> Filter(IEnumerable<Attribute> enumerable)
            {
                foreach (Attribute attribute in enumerable)
                {
                    if (attribute is AuthorAttribute)
                        yield return attribute;
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

            Assert.IsTrue(len == 2);
        }

        [Test]
        public void returns_1_attributes_if_ns_filter_is_applied()
        {
            int len = exec<Test>(new ns_filter()).Count();

            Assert.IsTrue(len == 1);
        }

        [Test]
        public void returns_MyAttribute_as_first_if_given_filter_is_ns_filter()
        {
            Attribute attrib = exec<Test>(new ns_filter())
                .SingleOrDefault(x => x is MyAttribute);
            
            Assert.NotNull(attrib);
        }

        [Test]
        public void returns_AuthorAttribute_as_first_if_given_filter_is_author_filter()
        {
            AuthorAttribute author = (AuthorAttribute) exec<Test>(new author_filter()).SingleOrDefault(x => x is AuthorAttribute);
            
            Assert.NotNull(author);
        }

        [Test]
        public void returns_0_if_both_filters_was_applied()
        {
            int len = exec<Test>(new author_filter(), new ns_filter()).Count();
            
            Assert.IsTrue(len == 0);
        }
    }
}