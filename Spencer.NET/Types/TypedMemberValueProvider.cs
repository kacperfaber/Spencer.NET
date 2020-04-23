using System;

namespace Spencer.NET
{
    public class TypedMemberValueProvider : ITypedMemberValueProvider
    {
        public object ProvideValue(Type type, IReadOnlyContainer container)
        {
            return container.ResolveOrDefault(type);
        }
    }
}