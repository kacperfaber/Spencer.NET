using System;
using System.Reflection;

namespace Odie
{
    public class ConstructorInfoListGenerator : IConstructorInfoListGenerator
    {
        public ConstructorInfo[] GenerateList(Type @class)
        {
            return @class.GetConstructors();
        }
    }
}