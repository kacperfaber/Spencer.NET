namespace Spencer.NET
{
    public interface IServiceConstructorProvider
    {
        IConstructor ProvideConstructor(IService service);
    }
}