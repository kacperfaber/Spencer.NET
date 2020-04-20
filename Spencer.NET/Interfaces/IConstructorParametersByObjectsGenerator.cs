namespace Spencer.NET
{
    public interface IConstructorParametersByObjectsGenerator
    {
        IConstructorParameters GenerateParameters(params object[] parameters);
    }
}