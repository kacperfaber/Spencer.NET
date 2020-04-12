using System;

namespace Odie
{
    public interface IMemberDeclarationTypeProvider
    {
        Type ProvideDeclarartionType(IMember member);
    }
}