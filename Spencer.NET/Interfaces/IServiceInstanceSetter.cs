namespace Spencer.NET
{
    public interface IServiceInstanceSetter
    {
        void SetInstance(IService service, object instance);
    }
}