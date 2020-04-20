using System;

namespace Spencer.NET
{
    public interface IClassHasServiceFactoryChecker
    {
        bool HasFactory(Type @class);
    }
}