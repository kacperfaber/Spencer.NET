using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class Interface : IInterface
    {
        private Type PrivateType;

        public Type Type
        {
            get { return PrivateType; }
            set
            {
                if (value.IsInterface)
                {
                    PrivateType = value;
                }

                else
                {
                    throw new InvalidOperationException($"Cannot create {nameof(Interface)} instance of {value.FullName}, because it is not interface.");
                }
            }
        }

        public bool HasGenericArguments { get; set; }
        public IEnumerable<Type> GenericParameters { get; set; }
    }
}