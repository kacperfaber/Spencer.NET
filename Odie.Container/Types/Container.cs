﻿using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public class Container : IContainer
    {
        public IEnumerable<Service> Services = new List<Service>();

        public IServiceResolver ServiceResolver = new ServiceResolver(new InstancesCreator(
            new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
            new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(), new ValueTypeActivator(),
                new TypeIsValueTypeChecker())));

        public IServiceRegistrar ServiceRegistrar = new ServiceRegistrar(new ServiceInstanceProvider(
            new InstancesCreator(new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
                new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(), new ValueTypeActivator(),
                    new TypeIsValueTypeChecker())), new ServiceIsAutoValueChecker()),new ServiceInstanceChecker());

        public IServiceGenerator ServiceGenerator = new ServiceGenerator(
            new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
            new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator()), new ServiceInfoGenerator());

        public IServiceFinder ServiceFinder = new ServiceFinder();

        public IServiceInitializer ServiceInitializer = new ServiceInitializer(new InstancesCreator(
            new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider()),
            new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterInfoHasDefaultValueChecker(), new ValueTypeActivator(),
                new TypeIsValueTypeChecker())));

        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker = new ServiceIsAutoValueChecker();
        public ITypeGetter TypeGetter = new TypeGetter();

        public object Resolve(Type key)
        {
            Service service = ServiceFinder.Find(Services, key);
            object result = ServiceResolver.Resolve(service, this, this);

            return result;
        }

        public T Resolve<T>()
        {
            Service service = ServiceFinder.Find(Services, typeof(T));
            return (T) ServiceResolver.Resolve(service, this, this);
        }

        public bool Has(Type key)
        {
            Service service = ServiceFinder.Find(Services, key);

            return service != null;
        }

        public void Register(Type type)
        {
            Service service = ServiceGenerator.GenerateService(type);

            if (ServiceIsAutoValueChecker.Check(service))
            {
                ServiceInitializer.Initialize(service, this, this);
            }

            ServiceRegistrar.Register(ref Services, service, this, this);
        }

        public void RegisterObject(object instance)
        {
            Service service = ServiceGenerator.GenerateService(TypeGetter.GetType(instance), instance);
            ServiceRegistrar.Register(ref Services, service, this, this);
        }

        public void RegisterObject<TKey>(object instance)
        {
            Service service = ServiceGenerator.GenerateService(typeof(TKey), instance);
            ServiceRegistrar.Register(ref Services, service, this, this);
        }

        public void RegisterObject(object instance, Type targetType)
        {
            Service service = ServiceGenerator.GenerateService(targetType, instance);
            ServiceRegistrar.Register(ref Services, service, this, this);
        }

        public void Register<T>()
        {
            Service service = ServiceGenerator.GenerateService(typeof(T));

            if (ServiceIsAutoValueChecker.Check(service))
            {
                ServiceInitializer.Initialize(service, this, this);
            }

            ServiceRegistrar.Register(ref Services, service, this, this);
        }
    }
}