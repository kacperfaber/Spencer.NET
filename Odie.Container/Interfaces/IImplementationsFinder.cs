using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IImplementationsFinder
    {
        IEnumerable<Type> FindImplementations(IEnumerable<Assembly> assemblies, Type @interface);
    }
}