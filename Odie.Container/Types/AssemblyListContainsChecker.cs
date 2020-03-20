﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class AssemblyListContainsChecker : IAssemblyListContainsChecker
    {
        public bool Contains(IAssemblyList list, Assembly assembly)
        {
            List<Assembly> assemblies = list.GetAssemblies();
            return assemblies.Contains(assembly);
        }
    }
}