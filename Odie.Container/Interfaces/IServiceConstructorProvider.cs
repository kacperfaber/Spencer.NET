namespace Odie
{
    public interface IServiceConstructorProvider
    {
        IConstructor ProvideConstructor(IService service);
    }
}