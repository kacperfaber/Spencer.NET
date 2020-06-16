using System;

namespace Spencer.NET
{
    public class InterfaceRegistrationBuilder : Builder<InterfaceRegistration, InterfaceRegistrationBuilder, InterfaceRegistration>, IDisposable
    {
        public InterfaceRegistrationBuilder(InterfaceRegistration model = null) : base(model)
        {
        }

        public InterfaceRegistrationBuilder AddClass<T>()
        {
        }

        public InterfaceRegistrationBuilder AddClasses(params Type[] @classes)
        {
        }

        public InterfaceRegistrationBuilder AddClass(Type @class)
        {
        }

        public InterfaceRegistrationBuilder AddImplementations()
        {
        }

        public ClassRegistrationBuilder SelectClass<T>() where T : class
        {
        }

        public ClassesRegistrationBuilder SelectClasses(params Type[] @classes)
        {
            
        }

        public void Dispose()
        {
        }
    }
}