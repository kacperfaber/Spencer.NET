using System;

namespace Odie
{
    public interface IAssignableChecker
    {
        bool Check(Type type, Type assignableTo);
    }
}