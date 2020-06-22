using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class AssemblyRegistrationBuilder : Builder<AssemblyRegistration, AssemblyRegistrationBuilder, AssemblyRegistration>
    {
        public AssemblyRegistrationBuilder(AssemblyRegistration model = null) : base(model)
        {
        }

        public AssemblyRegistrationBuilder ExcludeClass<TClass>() where TClass : class
        {
        }

        public AssemblyRegistrationBuilder IncludeClass<T>()
        {
        }

        public AssemblyRegistrationBuilder IncludeClasses(Func<Type, bool> func)
        {
        }

        public AssemblyRegistrationBuilder ExcludeClasses(Func<Type, bool> func)
        {
        }

        public AssemblyRegistrationBuilder FilterClasses(Func<IEnumerable<ClassRegistration>, IEnumerable<ClassRegistration>> filter)
        {
        }

        public ClassRegistrationBuilder SelectClass<T>()
        {
        }

        public ClassesRegistrationBuilder SelectClasses(Func<Type, bool> func)
        {
        }

        public ClassesRegistrationBuilder SelectClasses()
        {
        }
    }
}