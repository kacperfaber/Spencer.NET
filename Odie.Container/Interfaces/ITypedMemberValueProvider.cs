using System;

namespace Odie
{
    public interface ITypedMemberValueProvider
    {
        object ProvideValue(ITypedMember member, IContainer container);
    }
}