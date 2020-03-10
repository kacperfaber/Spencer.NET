using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ConstructorParametersGenerator
    {
        public static ConstructorParametersGenerator Current = new ConstructorParametersGenerator();

        public object[] GenerateParameters(ParameterInfo[] parameters, ServiceLoader loader)
        {
            List<object> outParameters = new List<object>();
            
            foreach (ParameterInfo info in parameters)
            {
                Type infoType = info.ParameterType;

                if (infoType.IsValueType)
                {
                    outParameters.Add(Activator.CreateInstance(infoType));
                }

                else
                {
                    if (info.HasDefaultValue)
                    {
                        outParameters.Add(info.DefaultValue);    
                    }
                    
                    if (loader.Has(infoType))
                    {
                        loader.Resolve(infoType);
                    }

                    else
                    {
                        loader.RegisterType(infoType);
                        outParameters.Add(loader.Resolve(infoType));
                    }
                }
            }

            return outParameters.ToArray();
        }
    }
}