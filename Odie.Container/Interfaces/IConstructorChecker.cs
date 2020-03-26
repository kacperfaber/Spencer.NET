using System.Reflection;

namespace Odie
{
    public interface IConstructorChecker
    {
        bool Check(IMember member);
    }
}