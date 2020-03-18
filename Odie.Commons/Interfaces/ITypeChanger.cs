namespace Odie
{
    public interface ITypeChanger
    {
        T ChangeType<T>(object instance) where T : class;
    }
}