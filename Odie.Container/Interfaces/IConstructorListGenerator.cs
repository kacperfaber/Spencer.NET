using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorListGenerator
    {
        IEnumerable<IConstructor> GenerateList(ConstructorInfo[] constructors);
    }
}