using System;

namespace Odie
{
    public interface IClassHasServiceFactoryChecker
    {
        bool HasFactory(Type @class);
    }
}