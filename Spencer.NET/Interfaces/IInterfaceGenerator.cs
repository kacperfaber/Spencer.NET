using System;

namespace Spencer.NET
{
    public interface IInterfaceGenerator
    {
        IInterface GenerateInterface(Type type);
    }
}