using System;

namespace Odie
{
    public interface ITypeExisterChecker
    {
        bool Check(IServiceList list, Type type);
    }
}