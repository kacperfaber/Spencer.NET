using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class RegisterParameterByTypeFinder : IRegisterParameterByTypeFinder
    {
        public IRegisterParameter FindByType(IRegisterParameters parameters, Type type)
        {
            return parameters.Parameters.First(x => type.IsAssignableFrom(x.Type));
        }
    }
}