using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie.Engine
{
    public class ValueGenerator : IValueGenerator
    {
        public List<ValueGeneratorExtension> Extensions;

        public ValueGenerator()
        {
            Extensions = new List<ValueGeneratorExtension>();
        }

        public object Generate(object parameters, Type parametersType, Type exceptedType, out Type valueType)
        {
            ValueGeneratorExtension ext = Extensions.SingleOrDefault(x => x.ActivationType == exceptedType);

            if (ext == null)
            {
                string message = $"{GetType().Name} does not supported gived type.\n but supports: ";

                foreach (ValueGeneratorExtension extension in Extensions)
                {
                    message += extension.ActivationType.Name;
                }
                
                throw new ArgumentException(message);
            }

            else
            {
                object res = ext.Function(parameters, parametersType);
                valueType = res.GetType();
                
                return res;
            }
            
        }
    }
}