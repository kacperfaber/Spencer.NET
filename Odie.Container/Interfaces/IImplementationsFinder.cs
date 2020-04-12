using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IImplementationsFinder
    {
        IEnumerable<Type> FindImplementations(IAssemblyList assemblies, Type @interface);
    }
}