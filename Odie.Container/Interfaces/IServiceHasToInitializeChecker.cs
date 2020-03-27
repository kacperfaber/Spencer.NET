namespace Odie
{
    public interface IServiceHasToInitializeChecker
    {
        bool Check(IService service);
    }
}