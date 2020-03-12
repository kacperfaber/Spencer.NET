using System;

namespace Odie
{
    public interface IInstanceCreator
    {
        // TODO - find ctor with valid parameters len, then compare parameter types isassignfrom.
        object CreateInstance(ServiceFlags flags, Type type, object[] instances);
    }
}