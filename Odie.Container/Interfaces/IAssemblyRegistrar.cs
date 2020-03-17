using System;

namespace Odie
{
    public interface IAssemblyRegistrar
    {
        void Register(Type type);
    }
}