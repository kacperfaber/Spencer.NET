using System;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class DefaultConstructorInfoProvider : IDefaultConstructorInfoProvider
    {
        public ConstructorInfo ProvideDefaultConstructor(ConstructorInfo[] constructorInfos)
        {
            return constructorInfos
                .Where(x => x.IsPublic)
                .OrderBy(x => x.GetParameters().Length)
                .FirstOrDefault();
        }
    }
}