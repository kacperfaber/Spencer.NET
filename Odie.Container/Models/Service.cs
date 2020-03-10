using System;
using System.Reflection;

namespace Odie
{
    public class Service
    {
        public Type ServiceType;
        public Type[] RegisteredAs;
        public Assembly Assembly;
        public ServiceFlag Flags;
        public Attribute[] Attributes;
        public ConstructorInfo DefaultConstructor;
        public MethodInfo DefaultFactory;
    }
}