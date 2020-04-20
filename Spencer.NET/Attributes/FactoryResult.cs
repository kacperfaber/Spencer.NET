using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
    public class FactoryResult : Attribute
    {
        public Type ResultType;
        
        public FactoryResult(Type producedType)
        {
            ResultType = producedType;
        }
    }
}