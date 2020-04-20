namespace Spencer.NET
{
    public class ConstructorParametersByObjectsGenerator : IConstructorParametersByObjectsGenerator
    {
        public ITypeGetter TypeGetter;

        public ConstructorParametersByObjectsGenerator(ITypeGetter typeGetter)
        {
            TypeGetter = typeGetter;
        }

        public IConstructorParameters GenerateParameters(params object[] parameters)
        {
            ConstructorParameters constructor = new ConstructorParameters();

            foreach (object p in parameters)
            {
                constructor.Add(new ConstructorParameter() {Type = TypeGetter.GetType(p), Value = p});
            }

            return constructor;
        }
    }
}