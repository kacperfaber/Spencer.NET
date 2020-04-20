using System;

namespace Spencer.NET
{
    public interface IAssignableChecker
    {
        bool Check(Type type, Type assignableTo);
    }
}