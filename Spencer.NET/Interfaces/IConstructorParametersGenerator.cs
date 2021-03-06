﻿using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IConstructorParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, ServiceFlags flags, IReadOnlyContainer container);
        
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IReadOnlyContainer container);
        
        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IConstructorParameters constructorParameters);

        IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IService service, IReadOnlyContainer container);
        IEnumerable<object> GenerateParameterValues(IConstructor constructor, IConstructorInstanceCreator instanceCreator);
    }
}