using System.Reflection;

namespace Odie
{
    public class ConstructorChecker : IConstructorChecker
    {
        public bool Check(MemberInfo member)
        {
            return member?.MemberType == MemberTypes.Constructor;
        }
    }
}