﻿using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class MethodParametersGenerator : IMethodParametersGenerator
    {
        public IEnumerable<IParameter> GenerateParameters(IMember member)
        {
            if (member.Instance is MethodInfo method)
            {
                ParameterInfo[] parameters = method.GetParameters();

                foreach (ParameterInfo param in parameters)
                {
                    yield return new ParameterBuilder()
                        .AddType(param.ParameterType)
                        .Build();
                }
            }
        }
    }
}