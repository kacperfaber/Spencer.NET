using System;
using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorInfoListGenerator : IConstructorInfoListGenerator
    {
        public ConstructorInfo[] GenerateList(Type @class)
        {
            return @class.GetConstructors();
        }
    }
}