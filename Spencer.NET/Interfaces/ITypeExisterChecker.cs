using System;

namespace Spencer.NET
{
    public interface ITypeExisterChecker
    {
        bool Check(IServiceList list, Type type);
    }
}