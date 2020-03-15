using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class TypeExisterChecker : ITypeExisterChecker
    {
        public ITypeContainsGenericParametersChecker GenericParametersChecker;
        public ITypeGenericParametersProvider GenericParametersProvider;

        public TypeExisterChecker(ITypeGenericParametersProvider genericParametersProvider, ITypeContainsGenericParametersChecker genericParametersChecker)
        {
            GenericParametersProvider = genericParametersProvider;
            GenericParametersChecker = genericParametersChecker;
        }

        public bool Check(ServicesList list, Type type)
        {
            if (GenericParametersChecker.Check(type))
            {
                IEnumerable<Type> keyParameters = GenericParametersProvider.ProvideGenericTypes(type);

                return list.GetServices()
                    .Where(x => x.Registration.GenericRegistration.HasGenericParameters)
                    .Where(x => x.Registration.GenericRegistration.GenericParameters.Count() == keyParameters.Count())
                    .Where(x => x.Registration.GenericRegistration.GenericParameters.SequenceEqual(keyParameters))
                    .FirstOrDefault() != null;
            }

            else
            {
                return list.GetServices().Where(x => type.IsAssignableFrom(x.Registration.TargetType)).FirstOrDefault() != null;
            }
        }
    }
}