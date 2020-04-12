﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ParametersValuesExtractor : IParametersValuesExtractor
    {
        public object[] ExtractValues(IEnumerable<IParameter> parameters)
        {
            return Array.ConvertAll(parameters.ToArray(), t => t.Value);
        }
    }
}