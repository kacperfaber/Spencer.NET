using System;
using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class ImplementationsFinder : IImplementationsFinder
    {
        public IInterfaceChecker InterfaceChecker;
        
        public Type[] FindImplementations(IEnumerable<Assembly> assemblies, Type @interface)
        {
            if (InterfaceChecker.IsInterface(@interface))
            {
                
            }
        }
    }
}