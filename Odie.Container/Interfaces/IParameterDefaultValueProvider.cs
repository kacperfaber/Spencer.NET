namespace Odie
{
    public interface IParameterDefaultValueProvider
    {
        object Provide(IParameter parameter);
    }
}