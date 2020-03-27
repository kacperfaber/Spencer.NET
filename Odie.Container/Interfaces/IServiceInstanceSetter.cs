namespace Odie
{
    public interface IServiceInstanceSetter
    {
        void SetInstance(IService service, object instance);
    }
}