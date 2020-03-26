using System.Reflection;

namespace Odie
{
    public class ConstructorChecker : IConstructorChecker
    {
        public bool Check(IMember member)
        {
            return member?.MemberType == MemberTypes.Constructor;
        }
    }
}