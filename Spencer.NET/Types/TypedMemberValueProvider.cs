using System;

namespace Spencer.NET
{
    public class TypedMemberValueProvider : ITypedMemberValueProvider
    {
        public object ProvideValue(Type type, IReadOnlyContainer container)
        {
            if (container is IContainer c)
                return c.ResolveOrAuto(type);

            return container.ResolveOrDefault(type); 
        }
    }
}