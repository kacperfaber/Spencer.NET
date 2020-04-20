using System;

namespace Spencer.NET
{
    public class AssignableChecker : IAssignableChecker
    {
        public bool Check(Type type, Type assignableTo)
        {
            return assignableTo.IsAssignableFrom(type);
        }
    }
}