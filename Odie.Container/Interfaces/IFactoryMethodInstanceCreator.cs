namespace Odie
{
    public interface IFactoryMethodInstanceCreator
    {
        object CreateInstance(IFactory factory, IReadOnlyContainer container);
    }
}