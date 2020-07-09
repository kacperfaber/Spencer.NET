using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class containerbuilder_registerassembly_tests
    {
        AssemblyRegistrationBuilder exec(ContainerBuilder builder, Assembly ass)
        {
            return builder.RegisterAssembly(ass);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new ContainerBuilder(), GetType().Assembly));
        }

        [Test]
        public void returns_instance_of_AssemblyRegistrationBuilder()
        {
            AssemblyRegistrationBuilder builder = exec(new ContainerBuilder(), GetType().Assembly);

            Assert.IsTrue(builder is AssemblyRegistrationBuilder);
        }

        [Test]
        public void container_has_more_registrations_than_before_resolving_AssemblyRegistrationBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();
            int before = builder.Registrations.Count;
            
            _ = exec(builder, GetType().Assembly);

            Assert.IsTrue(before < builder.Registrations.Count);
        }

        [Test]
        public void returns_same_IContainerRegistration_that_gived_in_container()
        {
            ContainerBuilder containerB = new ContainerBuilder();
            AssemblyRegistrationBuilder regB = exec(containerB, GetType().Assembly);

            Assert.NotNull(containerB.Registrations.SingleOrDefault(x => x.Equals(regB.Object)));
        }
    }
}