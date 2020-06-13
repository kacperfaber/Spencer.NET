using System;
using System.Reflection;

namespace Spencer.NET
{
    public interface IDefaultConstructorProvider
    {
        IConstructor ProvideDefaultConstructor(IService service);
    }
}