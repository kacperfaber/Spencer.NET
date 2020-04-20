namespace Spencer.NET
{
    public interface IFactoryGenerator
    {
        IFactory GenerateFactory(IMember member);
    }
}