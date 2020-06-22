using System;

namespace Spencer.NET
{
    public class ClassRegistration : TypeRegistration, IContainerRegistration
    {
        public Type Class { get; set; }
    }
}