using System;

namespace Spencer.NET
{
    public interface IContainerRegistrationConverterCreator
    {
        IContainerRegistrationConverter CreateInstance(Type type);
    }
}