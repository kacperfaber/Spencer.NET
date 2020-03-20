namespace Odie
{
    public interface IResolveParametersGenerator
    {
        IResolveParameters GenerateParameters(params object[] parameters);
    }
}