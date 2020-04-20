namespace Spencer.NET
{
    public interface IFactoryProvider
    {
        IFactory ProvideFactory(IService service);
    }
}