using System;

namespace Odie
{
    public class ValueTypeActivator : IValueTypeActivator
    {
        public object ActivateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}