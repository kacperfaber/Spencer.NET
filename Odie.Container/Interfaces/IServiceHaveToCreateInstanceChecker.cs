namespace Odie
{
    public interface IServiceHaveToCreateInstanceChecker
    {
        bool Check(IService service);
    }
}