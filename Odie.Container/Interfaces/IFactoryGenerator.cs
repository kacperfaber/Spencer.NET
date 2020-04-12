namespace Odie
{
    public interface IFactoryGenerator
    {
        IFactory GenerateFactory(IMember member);
    }
}