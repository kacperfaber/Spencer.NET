using System;
using System.Reflection;

namespace Odie
{
    public interface IConstructorInfoListGenerator
    {
        ConstructorInfo[] GenerateList(Type @class);
    }
}