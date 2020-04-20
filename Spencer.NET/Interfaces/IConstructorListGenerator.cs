using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IConstructorListGenerator
    {
        IEnumerable<IConstructor> GenerateList(ConstructorInfo[] constructors);
    }
}