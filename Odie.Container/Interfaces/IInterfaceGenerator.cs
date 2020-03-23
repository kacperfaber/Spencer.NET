using System;

namespace Odie
{
    public interface IInterfaceGenerator
    {
        IInterface GenerateInterface(Type type);
    }
}