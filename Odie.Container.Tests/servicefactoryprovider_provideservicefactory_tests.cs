using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class servicefactoryprovider_provideservicefactory_tests
    {
        class Test : IServiceFactory
        {
            public IService CreateService()
            {
                throw new NotImplementedException();
            }
        }

        IServiceFactory exec<T>()
        {
            ServiceFactoryProvider provider = new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(), new ValueTypeActivator(),
                    new TypeIsValueTypeChecker(),new ConstructorParameterByTypeFinder()), new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),new ConstructorListGenerator(), new ConstructorFinder())));

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