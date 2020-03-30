using System;

namespace Odie
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
            if (factory.Type == FactoryType.StaticMethod)
            {
                return MethodInstanceCreator.CreateInstance(factory, readOnlyContainer);
            }
            
            throw new NotImplementedException("Factory implements only .StaticMethod [0x0]");
        }
    }
}