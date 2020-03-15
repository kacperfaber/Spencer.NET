using System;
using System.Linq;

namespace Odie
{
    public class TypeExisterChecker : ITypeExisterChecker
    {
        public bool Check(ServicesList list, Type type)
        {
            return list.Services.Where(x => type.IsAssignableFrom(x.Registration.TargetType)).FirstOrDefault() != null;
        }
    }
}