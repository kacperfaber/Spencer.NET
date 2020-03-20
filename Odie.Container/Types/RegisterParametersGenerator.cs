using System.Runtime.ConstrainedExecution;

namespace Odie
{
    public class RegisterParametersGenerator : IRegisterParametersGenerator
    {
        public ITypeGetter TypeGetter;

        public RegisterParametersGenerator(ITypeGetter typeGetter)
        {
            TypeGetter = typeGetter;
        }

        public IRegisterParameters GenerateParameters(params object[] parameters)
        {
            RegisterParameters register = new RegisterParameters();

            foreach (object p in parameters)
            {
                register.Add(new RegisterParameter() {Type = TypeGetter.GetType(p), Value = p});
            }

            return register;
        }
    }
}