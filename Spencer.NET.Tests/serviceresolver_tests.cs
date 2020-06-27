#pragma warning disable
using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class serviceresolver_tests
    {
        [Test]
        public void is_IServiceResolver()
        {
            Assert.IsTrue(typeof(IServiceResolver).IsAssignableFrom(typeof(ServiceResolver)));
        }

        [Test]
        public void is_Obsolete()
        {
            Assert.NotNull(typeof(ServiceResolver).GetCustomAttribute(typeof(ObsoleteAttribute)));
        }

        [Test]
        public void has_Resolve_method()
        {
            Assert.NotNull(typeof(ServiceResolver).GetMethods().Where(x => x.Name == "Resolve"));
        }

        [Test]
        public void Resolve_method_returns_object()
        {
            MethodInfo method = typeof(ServiceResolver).GetMethods().SingleOrDefault(x => x.Name == "Resolve");

            Assert.IsTrue(method.ReturnType == typeof(object));
        }

        [Test]
        public void Resolve_method_takes_IService_and_IContainer()
        {
            MethodInfo method = typeof(ServiceResolver).GetMethods().SingleOrDefault(x => x.Name == "Resolve");

            ParameterInfo[] parameters = method.GetParameters();
            Type[] types = Array.ConvertAll(parameters, x => x.ParameterType);
            
            Assert.IsTrue(types.SequenceEqual(new [] {typeof(IService), typeof(IContainer)}));
        }

        [Test]
        public void Resolve_method_is_Obsolete()
        {
            MethodInfo method = typeof(ServiceResolver).GetMethods().SingleOrDefault(x => x.Name == "Resolve");

            Assert.NotNull(method.GetCustomAttribute(typeof(ObsoleteAttribute)));
        }

        [Test]
        public void has_public_constructor()
        {
            Assert.IsTrue(typeof(ServiceResolver).GetConstructors().Where(x => x.IsPublic).Any());
        }

        [Test]
        public void has_constructor_with_IServiceInstanceResolver_parameter()
        {
            Assert.IsTrue(typeof(ServiceResolver).GetConstructors().Where(x => x.GetParameters().FirstOrDefault().ParameterType == typeof(IServiceInstanceResolver)).Any());
        }
    }
}