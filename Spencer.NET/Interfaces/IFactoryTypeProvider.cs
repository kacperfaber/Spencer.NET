using System;

namespace Spencer.NET
{
    public interface IFactoryTypeProvider
    {
        Type ProvideType(Type declarationType, Attribute attribute);
    }
}