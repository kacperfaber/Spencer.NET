using System;

namespace Odie
{
    public interface ITypeServiceGenerator
    {
        Service GenerateService(Type @class, object instance = null);
    }
}