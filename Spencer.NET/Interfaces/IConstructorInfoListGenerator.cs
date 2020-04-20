using System;
using System.Reflection;

namespace Spencer.NET
{
    public interface IConstructorInfoListGenerator
    {
        ConstructorInfo[] GenerateList(Type @class);
    }
}