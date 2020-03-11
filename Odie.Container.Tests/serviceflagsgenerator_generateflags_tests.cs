using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class serviceflagsgenerator_generateflags_tests
    {
        [MultiInstance]
        [AutoValue]
        class test1
        {
            [DefaultConstructor]
            public test1()
            {
            }

            [Factory]
            public test1 Create() => default;
        }

        ServiceFlag exec<T>()
        {
            ServiceFlagsGenerator generator = new ServiceFlagsGenerator(new ServiceFlagsAttributeArrayGenerator(new TypeAttributesGetter(), new MemberInfosAttributesGetter()));
            return generator.GenerateFlags(typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<test1>());
        }

        [Test]
        public void returns_excepted_flags_values()
        {
            ServiceFlag flag = exec<test1>();
            
            Assert.IsTrue(flag.HasFlag(ServiceFlag.HAS_CONSTRUCTOR));
            Assert.IsTrue(flag.HasFlag(ServiceFlag.AUTO_VALUE));
            Assert.IsTrue(flag.HasFlag(ServiceFlag.MULTI_INSTANCE));
            Assert.IsTrue(flag.HasFlag(ServiceFlag.HAS_FACTORY));
        }
    }
}