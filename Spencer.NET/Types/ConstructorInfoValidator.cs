using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorInfoValidator : IConstructorInfoValidator
    {
        public bool Validate(ConstructorInfo constructorInfo)
        {
            if (constructorInfo != null)
                return constructorInfo.IsPublic;

            return false;
        }
    }
}