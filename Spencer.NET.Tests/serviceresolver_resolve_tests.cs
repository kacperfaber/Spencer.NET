using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable CS0612

namespace Spencer.NET.Tests
{
    public class serviceresolver_resolve_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        object exec(IContainer container, IService service)
        {
            ServiceResolver resolver = new ServiceResolver((container as Container).ServiceInstanceResolver);
            return resolver.Resolve(service, container);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer c = ContainerFactory.Container();
            IService service = new Service
            {
                Registration = new ServiceRegistration
                {
                    TargetType = typeof(TestClass),
                    RegistrationFlags = new List<ServiceRegistrationFlag>()
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)
                    }
                },
                Data = new ServiceData
                {
                    Instance = null
                }
            };

            Assert.DoesNotThrow(() => exec(c, service));
        }

        [Test]
        public void returns_Service_Data_Instance_if_she_was_not_null_and_service_is_SingleInstance()
        {
            object excepted = new object();

            IContainer c = ContainerFactory.Container();

            IService service = new Service
            {
                Data = new ServiceData
                {
                    Instance = excepted
                },
                Registration = new ServiceRegistration()
                {
                    TargetType = typeof(TestClass),
                    RegistrationFlags = new List<ServiceRegistrationFlag>()
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)
                    }
                }
            };

            object o = exec(c, service);

            Assert.AreEqual(service.Data.Instance, o);
        }

        [Test]
        public void returns_new_instance_of_target_object_if_Service_Data_Instance_was_null_and_service_is_SingleInstance()
        {
            object excepted = new object();

            IContainer c = ContainerFactory.Container();

            IService service = new Service
            {
                Data = new ServiceData(),
                Registration = new ServiceRegistration()
                {
                    TargetType = typeof(TestClass),
                    RegistrationFlags = new List<ServiceRegistrationFlag>()
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)
                    }
                }
            };

            object o = exec(c, service);

            Assert.AreNotEqual(excepted, o);
        }

        [Test]
        public void returns_new_instance_if_Service_Data_Instance_is_setted_and_service_is_MultiInstance()
        {
            object excepted = new TestClass();

            IContainer c = ContainerFactory.Container();
            
            IService service = new Service
            {
                Data = new ServiceData
                {
                    Instance = excepted
                },
                Registration = new ServiceRegistration
                {
                    TargetType = typeof(TestClass),
                    RegistrationFlags = new List<ServiceRegistrationFlag>
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.IsMultiInstance, null)
                    }
                }
            };

            object o = exec(c, service);
            
            Assert.AreNotEqual(excepted, o);
        }

        [Test]
        public void returns_two_same_instances_if_Service_Data_Instance_was_null_and_service_was_SingleInstance()
        {
            IContainer c = ContainerFactory.Container();
            
            IService service = new Service
            {
                Data = new ServiceData
                {
                    Instance = null
                },
                Registration = new ServiceRegistration()
                {
                    TargetType = typeof(TestClass),
                    RegistrationFlags = new List<ServiceRegistrationFlag>()
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)
                    }
                }
            };

            object res1 = exec(c, service);
            object res2 = exec(c, service);
            
            Assert.AreEqual(res1, res2);
        }

        [Test]
        public void returning_new_instance_and_sets_it_to_Service_Data_Instance_if_Service_Data_Instance_was_null_and_service_was_SingleInstance()
        {
            object excepted = new object();

            IContainer c = ContainerFactory.Container();
            
            IService service = new Service
            {
                Data = new ServiceData
                {
                    Instance = null
                },
                Registration = new ServiceRegistration
                {
                    TargetType = typeof(TestClass),
                    RegistrationFlags = new List<ServiceRegistrationFlag>
                    {
                        new ServiceRegistrationFlag(RegistrationFlagConstants.IsSingleInstance, null)
                    }
                }
            };

            object o = exec(c, service);
            
            Assert.AreEqual(service.Data.Instance, o);
        }
    }
}