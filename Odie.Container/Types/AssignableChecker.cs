using System;

namespace Odie
{
    public class AssignableChecker : IAssignableChecker
    {
        public bool Check(Type type, Type assignableTo)
        {
            return assignableTo.IsAssignableFrom(type);
        }
    }
}