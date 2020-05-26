using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface ITypedFactoryExistChecker
    {
        bool CheckExist(IEnumerable<Attribute> attributes);
    }
}