using System.Reflection;

namespace Spencer.NET
{
    public interface IConstructorInfoValidator
    {
        bool Validate(ConstructorInfo constructorInfo);
    }
}