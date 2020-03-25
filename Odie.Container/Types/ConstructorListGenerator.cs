using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
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