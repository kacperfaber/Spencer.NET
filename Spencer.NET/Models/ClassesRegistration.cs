using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ClassesRegistration : TypeRegistration, IContainerRegistration
    {
        public List<ClassRegistration> ClassRegistrations { get; set; }

        public ClassesRegistration()
        {
            ClassRegistrations = new List<ClassRegistration>();
        }
    }
}