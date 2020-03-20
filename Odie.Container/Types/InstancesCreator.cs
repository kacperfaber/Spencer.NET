using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class InstancesCreator : IInstanceCreator
    {
        public IConstructorInstanceCreator CtorInstanceCreator;

        public InstancesCreator(IConstructorInstanceCreator ctorInstanceCreator)
        {
            CtorInstanceCreator = ctorInstanceCreator;
        }

        public object CreateInstance(ServiceFlags flags, Type type, IContainer container)
        {
            return CtorInstanceCreator.CreateInstance(flags, type, container);
        }

        public object CreateInstance(Type type, IContainer container)
        {
            return CtorInstanceCreator.CreateInstance(type, container);
        }

        public object CreateInstance(Type type, IRegisterParameter registerParameter)
        {
            return CtorInstanceCreator.CreateInstance(type, (IRegisterParameters) registerParameter);
        }
    }
}