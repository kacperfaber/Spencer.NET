namespace Odie
{
    public interface IObjectPostProcessor
    {
        void Process(object instance, IService service, IReadOnlyContainer container);
    }
}