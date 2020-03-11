using System;

namespace Odie
{
    public interface IServiceFlagsMemberAttributeFinder
    {
        bool IsExist(Type type, Type attributeType);
    }
}