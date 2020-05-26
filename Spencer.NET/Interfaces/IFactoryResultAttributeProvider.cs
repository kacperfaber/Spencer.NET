using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IFactoryResultAttributeProvider
    {
        Attribute ProvideAttributeOrNull(IEnumerable<Attribute> attributes);
    }
}