using System;
using System.Reflection;

namespace Odie
{
    public interface IRegisterParameterByTypeFinder
    {
        IRegisterParameter FindByType(IRegisterParameters parameters, Type type);
    }
}