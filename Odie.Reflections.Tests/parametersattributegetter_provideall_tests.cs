using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Odie.Reflections.Tests
{
    public class parametersattributegetter_provideall_tests
    {
        class Test
        {
            [IntegerRange(0, 100)]
            [JsonIgnore]
            public int Integer { get; set; }
        }
        
        ParametersAttribute[] exec()
        {
            return new ParametersAttributeGetter(new ArrayTypeChanger(), new ParametersAttributeTypeProvider()).ProvideAll(typeof(Test).GetProperty("Integer"));       
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_len_1()
        {
            Assert.IsTrue(exec().Count() == 1);
        }
    }
}