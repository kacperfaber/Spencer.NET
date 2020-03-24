namespace Odie
{
    public interface IFactoryProvider
    {
        IFactory ProvideFactory(IService service);
    }
}