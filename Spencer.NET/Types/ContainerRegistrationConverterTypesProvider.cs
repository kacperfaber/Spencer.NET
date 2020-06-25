using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ContainerRegistrationConverterTypesProvider : IContainerRegistrationConverterTypesProvider
    {
        public IEnumerable<Type> ProvideTypes(Assembly scanningAssembly)
        {
            return scanningAssembly
                .GetTypes()
                .Where(x => x.IsClass)
                .Where(x => typeof(IContainerRegistrationConverter).IsAssignableFrom(x))
                .Where(x => x.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0) != null);
        }
    }
}