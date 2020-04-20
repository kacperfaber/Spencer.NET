using System;

namespace Spencer.NET
{
    public interface IConstructorParameterByTypeFinder
    {
        IConstructorParameter FindByType(IConstructorParameters parameters, Type type);
    }
}