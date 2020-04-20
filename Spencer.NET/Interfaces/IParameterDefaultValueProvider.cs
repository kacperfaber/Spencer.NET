namespace Spencer.NET
{
    public interface IParameterDefaultValueProvider
    {
        object Provide(IParameter parameter);
    }
}