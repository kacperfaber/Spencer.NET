using System;

namespace Spencer.NET
{
    public class ValueTypeActivator : IValueTypeActivator
    {
        public object ActivateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}