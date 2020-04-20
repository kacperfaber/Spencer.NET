using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IAssemblyImplementationsFinder
    {
        IEnumerable<Type> FindImplementations(Assembly assembly, Type @interface);
    }
}