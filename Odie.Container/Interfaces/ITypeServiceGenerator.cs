using System;

namespace Odie
{
    public interface ITypeServiceGenerator
    {
        Service GenerateService(Type @class, IContainer container, object instance = null);
    }
}