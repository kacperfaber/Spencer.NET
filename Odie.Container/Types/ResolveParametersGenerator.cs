using System.Runtime.ConstrainedExecution;

namespace Odie
{
    public class ResolveParametersGenerator : IResolveParametersGenerator
    {
        public ITypeGetter TypeGetter;

        public ResolveParametersGenerator(ITypeGetter typeGetter)
        {
            TypeGetter = typeGetter;
        }

        public IResolveParameters GenerateParameters(params object[] parameters)
        {
            ResolveParameters resolve = new ResolveParameters();

            foreach (object p in parameters)
            {
                resolve.Add(new ResolveParameter() {Type = TypeGetter.GetType(p), Value = p});
            }

            return resolve;
        }
    }
}