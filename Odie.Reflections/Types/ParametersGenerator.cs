using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ParametersGenerator : IParametersGenerator
    {
        public IParametersAttributesGetter AttributesGetter;

        public ParametersGenerator(IParametersAttributesGetter attributesGetter)
        {
            AttributesGetter = attributesGetter;
        }

        public Parameters GenerateParameters(MemberInfo member)
        {
            Parameters parameters = new Parameters();
            ParametersAttribute[] attributes = AttributesGetter.ProvideAll(member);

            foreach (ParametersAttribute parametersAttribute in attributes)
            {
                parameters
                    .Types
                    .ToList()
                    .Add(parametersAttribute.ValueType);

                parameters
                    .Values
                    .ToList()
                    .Add(parametersAttribute.Value);
            }

            return parameters;
        }
    }
}