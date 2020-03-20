namespace Odie
{
    public interface IRegisterParametersGenerator
    {
        IRegisterParameters GenerateParameters(params object[] parameters);
    }
}