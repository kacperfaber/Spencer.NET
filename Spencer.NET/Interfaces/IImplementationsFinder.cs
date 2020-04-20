using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IImplementationsFinder
    {
        IEnumerable<Type> FindImplementations(IAssemblyList assemblies, Type @interface);
    }
}