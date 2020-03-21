using System;
using System.Reflection;

namespace Odie
{
    public interface IConstructorParameterByTypeFinder
    {
        IConstructorParameter FindByType(IConstructorParameters parameters, Type type);
    }
}