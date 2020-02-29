using System;

namespace Odie.Engine
{
    public interface IGenerator
    {
        Field Generate(Property property);
    }
}