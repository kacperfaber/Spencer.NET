using System;

namespace Odie
{
    public interface IValueTypeActivator
    {
        object ActivateInstance(Type type);
    }
}