using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class containerregistrationconvertersprovider_provideconverters_tests
    {
        List<IContainerRegistrationConverter> exec()
        {
            ContainerRegistrationConvertersProvider provider = new ContainerRegistrationConvertersProvider(new ContainerRegistrationConverterTypesProvider(),
                new ContainerRegistrationConvertersCreator(new ContainerRegistrationConverterCreator()));

            return provider.ProvideConverters(GetType().Assembly);
        }

        class SampleRegistration : IContainerRegistration
        {
        }

        class SampleConverter : IContainerRegistrationConverter<SampleRegistration>
        {
            public SampleConverter()
            {
            }

            public IEnumerable<IService> Convert(SampleRegistration registration)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_not_empty()
        {
            Assert.IsNotEmpty(exec());
        }

        [Test]
        public void returns_SampleConverter()
        {
            List<IContainerRegistrationConverter> converters = exec();
            IContainerRegistrationConverter sampleConverter = converters.FirstOrDefault(x => x is SampleConverter);
            
            Assert.NotNull(sampleConverter);
        }

        [Test]
        public void each_object_is_IContainerRegistrationConverter()
        {
            Assert.IsTrue(exec().All(x => x is IContainerRegistrationConverter));
        }
    }
}