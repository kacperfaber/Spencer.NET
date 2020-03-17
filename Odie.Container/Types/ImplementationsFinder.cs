using System;
using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie
{
    public class ImplementationsFinder : IImplementationsFinder
    {
        public IInterfaceChecker InterfaceChecker;
        
        public IEnumerable<Type> FindImplementations(AssemblyList assemblies, Type @interface)
        {
            // TODO

            throw new NotImplementedException();
        }
    }
}