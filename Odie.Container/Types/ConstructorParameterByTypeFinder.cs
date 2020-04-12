﻿using System;
using System.Linq;

namespace Odie
{
    public class ConstructorParameterByTypeFinder : IConstructorParameterByTypeFinder
    {
        public IConstructorParameter FindByType(IConstructorParameters parameters, Type type)
        {
            IConstructorParameter selected = parameters.Parameters.First(x => type.IsAssignableFrom(x.Type));
            parameters.Parameters.Remove(selected);

            return selected;
        }
    }
}