using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorChecker : IConstructorChecker
    {
        public bool Check(IMember member)
        {
            return member?.Instance?.MemberType == MemberTypes.Constructor;
        }
    }
}