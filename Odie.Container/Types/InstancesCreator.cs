using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class InstancesCreator : IInstanceCreator
    {
        public IConstructorInstanceCreator CtorInstanceCreator;
        public IClassChecker ClassChecker;

        public InstancesCreator(IConstructorInstanceCreator ctorInstanceCreator)
        {
            CtorInstanceCreator = ctorInstanceCreator;
        }

        public object CreateInstance(ServiceFlags flags, Type type, IContainer container)
        {
            return CtorInstanceCreator.CreateInstance(flags, type, container);
        }
    }
}