using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IConstructorFinder
    {
        IConstructor FindBy(IEnumerable<IConstructor> ctors, IConstructorParameters constructorParameters);
    }
}