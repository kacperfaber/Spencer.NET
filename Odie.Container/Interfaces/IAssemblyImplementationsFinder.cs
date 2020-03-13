using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IAssemblyImplementationsFinder
    {
        IEnumerable<Type> FindImplementations(Assembly assembly, Type @interface);
    }
}