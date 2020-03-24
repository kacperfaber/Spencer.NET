using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class MethodParametersGenerator : IMethodParametersGenerator
    {
        public IEnumerable<IParameter> GenerateParameters(MemberInfo member)
        {
            if (member is MethodInfo method)
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