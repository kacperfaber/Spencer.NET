namespace Spencer.NET
{
    public class ParameterDefaultValueProvider : IParameterDefaultValueProvider
    {
        public object Provide(IParameter parameter)
        {
            return parameter.DefaultValue;
        }
    }
}