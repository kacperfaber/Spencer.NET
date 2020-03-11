namespace Odie
{
    public class Container : IContainer
    {
        public static IContainer Current = new Container();
        
        public T Resolve<T>()
        {
            return default;
        }

        public T Resolve<TKey, T>()
        {
            return default;
        }
    }
}