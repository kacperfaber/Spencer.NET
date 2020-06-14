using System;

namespace Spencer.NET
{
    public class FactoryInstanceCreator : IFactoryInstanceCreator
    {
        public IFactoryMethodInstanceCreator MethodInstanceCreator;

        public FactoryInstanceCreator(IFactoryMethodInstanceCreator methodInstanceCreator)
        {
            MethodInstanceCreator = methodInstanceCreator;
        }

        public object CreateInstance(IFactory factory, IService service, IReadOnlyContainer readOnlyContainer)
        {
            return MethodInstanceCreator.CreateInstance(factory, readOnlyContainer);
        }
    }
}