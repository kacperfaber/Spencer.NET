using System;

namespace Spencer.NET
{
    public interface IMemberDeclarationTypeProvider
    {
        Type ProvideDeclarartionType(IMember member);
    }
}