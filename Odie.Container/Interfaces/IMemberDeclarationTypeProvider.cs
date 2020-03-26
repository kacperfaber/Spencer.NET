using System;
using System.Reflection;

namespace Odie
{
    public interface IMemberDeclarationTypeProvider
    {
        Type ProvideDeclarartionType(IMember member);
    }
}