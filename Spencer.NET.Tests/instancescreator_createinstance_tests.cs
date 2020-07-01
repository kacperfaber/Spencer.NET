using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class instancescreator_createinstance_tests
    {
        interface ITest1
        {
        }

        class Dep1 : ITest1
        {
        }

        class TestClass
        {
            public Dep1 test;

            public TestClass(Dep1 test1)
            {
                test = test1;
            }
        }

        class TestContainer : IContainer
        {
            public object Resolve(Type type)
            {
                if (type == typeof(Dep1))
                {
                    return new Dep1();
                }

                throw new ArgumentException();
            }

            public T Resolve<T>()
            {
                throw new NotImplementedException();
            }

            public T ResolveOrAuto<T>()
            {
                throw new NotImplementedException();
            }

            public object ResolveOrAuto(Type type)
            {
                throw new NotImplementedException();
            }

            public T ResolveOrDefault<T>()
            {
                throw new NotImplementedException();
            }

            public object ResolveOrDefault(Type type)
            {
                throw new NotImplementedException();
            }

            public T Resolve<T>(params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<T> ResolveMany<T>()
            {
                throw new NotImplementedException();
            }

            public IEnumerable<object> ResolveMany(Type type)
            {
                throw new NotImplementedException();
            }

            public bool Has<T>()
            {
                throw new NotImplementedException();
            }

            public bool Has(Type type)
            {
                if (type == typeof(Dep1))
                {
                    return true;
                }

                return false;
            }

            public void Register(Type type)
            {
                throw new NotImplementedException();
            }

            public void Register<T>()
            {
                throw new NotImplementedException();
            }

            public void RegisterObject(object instance)
            {
                throw new NotImplementedException();
            }

            public void RegisterObject<TKey>(object instance)
            {
                throw new NotImplementedException();
            }

            public void RegisterObject(object instance, Type targetType)
            {
                throw new NotImplementedException();
            }

            public void RegisterAssembly(Assembly assembly)
            {
                throw new NotImplementedException();
            }

            public void RegisterAssembly<T>()
            {
                throw new NotImplementedException();
            }

            public void RegisterAssemblies(params Assembly[] assemblies)
            {
                throw new NotImplementedException();
            }

            public void Register<T>(params object[] parameters)
            {
                throw new NotImplementedException();
            }

            public IStorage Storage { get; set; }
        }

        object exec<T>()
        {
            TypedMemberValueProvider typedMemberValueProvider = new TypedMemberValueProvider();

            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(),
                ServiceGeneratorFactory.MakeInstance());
            IEnumerable<IService> service = generator.GenerateServices(typeof(T), new AssemblyList(), null, null);

            InstancesCreator creator = new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                new ConstructorParametersGenerator(typedMemberValueProvider, new ConstructorParameterByTypeFinder(),
                    new ServiceHasConstructorParametersChecker()),
                new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorInfoProvider(),
                    new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ConstructorInfoListGenerator(), new ConstructorFinder(),
                new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))), new ParametersValuesExtractor()));

            IContainer container = ContainerFactory.Container();
            container.Register<T>();
            container.Register<Dep1>();
            container.Register<TestClass>();

            object instance = creator.CreateInstance(service.First().Flags, service.First().Registration.TargetType, container);

            return instance;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_typeof_TestClass()
        {
            Assert.IsTrue(exec<TestClass>().GetType() == typeof(TestClass));
        }

        [Test]
        public void returns_TestClass_dot_test_not_null()
        {
            Assert.NotNull(((TestClass) exec<TestClass>()).test);
        }
    }
}