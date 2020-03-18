namespace Odie
{
    public class TypeChanger : ITypeChanger
    {
        public T ChangeType<T>(object instance) where T : class
        {
            return instance as T;
        }
    }
}