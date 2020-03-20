using System;
using System.Reflection;

namespace Odie
{
    public interface IConstructorListGenerator
    {
        ConstructorInfo[] GenerateList(Type @class);
    }
}