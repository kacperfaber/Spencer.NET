using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ContainerDelegateFinder
    {
        public static ContainerDelegateFinder Current = new ContainerDelegateFinder();

        private static Type InterfaceType = typeof(IContainerDelegate);
        private static Type AttributeType = typeof(ContainerDelegateAttribute);

        public IEnumerable<Type> FindDelegates(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();

            return types
                .Where(x => Attribute.GetCustomAttributes(AttributeType).Any())
                .Where(x => x.GetInterfaces().Contains(InterfaceType));
        }
    }
}