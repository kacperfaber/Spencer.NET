using System;
using System.Collections.Generic;

namespace Odie.Reflections
{
    public interface IReflectionFieldsGetter
    {
        IEnumerable<ReflectionField> Get(Type type, MemberType memberTypes = MemberType.PROPERTY);
    }
}