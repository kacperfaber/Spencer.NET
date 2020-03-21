namespace Odie
{
    public interface IConstructorParametersByObjectsGenerator
    {
        IConstructorParameters GenerateParameters(params object[] parameters);
    }
}