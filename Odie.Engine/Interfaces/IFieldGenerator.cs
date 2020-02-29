using System;

namespace Odie.Engine
{
    public interface IFieldGenerator
    {
        Field Generate(Property property);
    }
}