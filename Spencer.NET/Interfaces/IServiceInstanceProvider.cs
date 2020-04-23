namespace Spencer.NET
{
    public interface IServiceInstanceProvider
    {
        void ProvideInstance(IService service);
    }
}