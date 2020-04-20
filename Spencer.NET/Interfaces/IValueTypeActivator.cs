using System;

namespace Spencer.NET
{
    public interface IValueTypeActivator
    {
        object ActivateInstance(Type type);
    }
}