using System;

namespace Spencer.NET
{
    public class InjectValueProvider : IInjectValueProvider
    {
        public object ProvideValue(Type type, IReadOnlyContainer container)
        {
            if (container is Container c)
                return c.ResolveOrAuto(type);
            
            return container.ResolveOrDefault(type);
        }
    }
}