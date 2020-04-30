using System;

namespace Spencer.NET
{
    public class InjectValueProvider : IInjectValueProvider
    {
        public object ProvideValue(Type type, IReadOnlyContainer container)
        {
            return container.ResolveOrDefault(type);
        }
    }
}