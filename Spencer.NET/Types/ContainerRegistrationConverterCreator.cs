using System;

namespace Spencer.NET
{
    public class ContainerRegistrationConverterCreator : IContainerRegistrationConverterCreator
    {
        public IContainerRegistrationConverter CreateInstance(Type type)
        {
            return (IContainerRegistrationConverter) Activator.CreateInstance(type);
        }
    }
}