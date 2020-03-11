using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class ServiceFlagsAttributeArrayGenerator : IServiceFlagsAttributeArrayGenerator
    {
        public IMemberInfosAttributeGetter MemberFinder;
        public ITypeAttributesGetter TypeGetter;

        public ServiceFlagsAttributeArrayGenerator(ITypeAttributesGetter typeGetter, IMemberInfosAttributeGetter memberFinder)
        {
            TypeGetter = typeGetter;
            MemberFinder = memberFinder;
        }

        public ServiceFlagAttribute[] Generate(Type type)
        {
            IEnumerable<ServiceFlagAttribute> attributes = TypeGetter.GetAttributes<ServiceFlagAttribute>(type);
            IEnumerable<ServiceFlagAttribute> membersAttributes = MemberFinder.GetAttributes<ServiceFlagAttribute>(type);
            
            List<ServiceFlagAttribute> a = new List<ServiceFlagAttribute>();
            a.AddRange(attributes);
            a.AddRange(membersAttributes);

            return a.ToArray();
        }
    }
}