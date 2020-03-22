using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IConstructorFinder
    {
        IConstructor FindBy(IEnumerable<IConstructor> ctors, IConstructorParameters constructorParameters);
    }
}