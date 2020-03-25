using System;

namespace Odie
{
    public interface IParameter : ITypedMember
    {
        object Value { get; set; }
        
        bool HasDefaultValue { get; set; }
        
        object DefaultValue { get; set; }
    }
}