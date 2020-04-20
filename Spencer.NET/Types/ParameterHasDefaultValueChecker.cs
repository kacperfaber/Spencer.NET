namespace Spencer.NET
{
    public class ParameterHasDefaultValueChecker : IParameterHasDefaultValueChecker
    {
        public bool Check(IParameter parameter)
        {
            return parameter.HasDefaultValue;
        }
    }
}