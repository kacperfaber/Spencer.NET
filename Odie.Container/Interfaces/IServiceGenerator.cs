using System;

namespace Odie
{
    public interface IServiceGenerator
    {
        Service GenerateService(Type type);
    }
}