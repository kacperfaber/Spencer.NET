using System;
using System.Reflection;

namespace Spencer.NET
{
    public interface IDefaultConstructorInfoProvider
    {
        ConstructorInfo ProvideDefaultConstructor(ConstructorInfo[] constructorInfos);
    }
}