using System;
using System.Reflection;

namespace Odie
{
    public class ConstructorListGenerator : IConstructorListGenerator
    {
        public ConstructorInfo[] GenerateList(Type @class)
        {
            return @class.GetConstructors();
        }
    }
}