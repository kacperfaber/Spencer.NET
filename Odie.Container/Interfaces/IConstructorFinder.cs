using System.Collections.Generic;

namespace Odie
{
    public interface IConstructorFinder
    {
        IConstructor FindBy(IEnumerable<IConstructor> ctors, IConstructorParameters constructorParameters);
    }
}