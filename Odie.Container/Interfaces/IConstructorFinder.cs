using System.Reflection;

namespace Odie
{
    public interface IConstructorFinder
    {
        ConstructorInfo FindBy(ConstructorInfo[] ctors, IConstructorParameters constructorParameters);
    }
}