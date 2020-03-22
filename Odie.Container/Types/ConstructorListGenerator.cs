using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ConstructorListGenerator : IConstructorListGenerator
    {
        public IEnumerable<IConstructor> GenerateList(ConstructorInfo[] constructors)
        {
            return Array.ConvertAll(constructors, c => new ConstructorBuilder().AddInstance(c).AddParameters(c.GetParameters()).Build());
        }
    }
}