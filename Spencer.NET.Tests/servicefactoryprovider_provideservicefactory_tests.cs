using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicefactoryprovider_provideservicefactory_tests
    {
        class Test : IServiceFactory
        {
            public IService CreateService()
            {
                return null;
            }
        }

        IServiceFactory exec<T>()
        {
            ServiceFactoryProvider provider = new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                new ConstructorParametersGenerator(new TypedMemberValueProvider(), new ConstructorParameterByTypeFinder(),
                    new ServiceHasConstructorParametersChecker()),
                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                    new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(), new ConstructorFinder(),
                new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ParametersValuesExtractor())));

            return provider.ProvideServiceFactory(typeof(T), null);
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<Test>());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test>());
        }

        [Test]
        public void throws_notimplementedexception_if_invoked_createservice_of_result()
        {
            Exception exception = Assert.Catch(() => exec<Test>().CreateService());

            Assert.AreEqual(typeof(NotImplementedException), exception.GetType());
        }
    }
}