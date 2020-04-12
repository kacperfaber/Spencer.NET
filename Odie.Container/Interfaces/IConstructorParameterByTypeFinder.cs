using System;

namespace Odie
{
    public interface IConstructorParameterByTypeFinder
    {
        IConstructorParameter FindByType(IConstructorParameters parameters, Type type);
    }
}