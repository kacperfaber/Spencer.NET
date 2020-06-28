using System;
using System.Reflection;
using System.Reflection.Emit;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_registerassembly_tests
    {
        void exec(IContainerRegistrar registrar, Assembly assembly = null)
        {
            assembly ??= GetType().Assembly;

            registrar.RegisterAssembly(assembly);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(ContainerFactory.Container()));
        }

        [Test]
        public void container_Storage_Services_is_more_than_before_registration()
        {
            IContainer container = ContainerFactory.Container();
            int before = container.Storage.Services.GetServices().Count;
            exec(container);
            int after = container.Storage.Services.GetServices().Count;
            
            Assert.IsTrue(after > before);
        }
    }
}