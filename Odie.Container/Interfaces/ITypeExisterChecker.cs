using System;

namespace Odie
{
    public interface ITypeExisterChecker
    {
        bool Check(ServicesList list, Type type);
    }
}