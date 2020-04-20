using System;

namespace Spencer.NET
{
    public class InstancesCreator : IInstanceCreator
    {
        public IConstructorInstanceCreator CtorInstanceCreator;

        public InstancesCreator(IConstructorInstanceCreator ctorInstanceCreator)
        {
            CtorInstanceCreator = ctorInstanceCreator;
        }

        public object CreateInstance(ServiceFlags flags, Type type, IReadOnlyContainer container)
        {
            return CtorInstanceCreator.CreateInstance(flags, type, container);
        }

        public object CreateInstance(Type type, IReadOnlyContainer container)
        {
            return CtorInstanceCreator.CreateInstance(type, container);
        }

        public object CreateInstance(Type type, IConstructorParameters constructorParameter)
        {
            return CtorInstanceCreator.CreateInstance(type, constructorParameter);
        }
    }
}