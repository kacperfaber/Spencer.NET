using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorListGenerator : IConstructorListGenerator
    {
        public IConstructorGenerator ConstructorGenerator;

        public ConstructorListGenerator(IConstructorGenerator constructorGenerator)
        {
            ConstructorGenerator = constructorGenerator;
        }

        public IEnumerable<IConstructor> GenerateList(ConstructorInfo[] constructors)
        {
            return Array.ConvertAll(constructors, c => ConstructorGenerator.GenerateConstructor(c));
        }
    }
}