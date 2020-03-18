using System.Collections.Generic;

namespace Odie
{
    public class ArrayTypeChanger : IArrayTypeChanger
    {
        public IEnumerable<T> ChangeType<T>(IEnumerable<object> enumerable)
        {
            foreach (object o in enumerable)
            {
                yield return (T) o;
            }
        }

        public T[] ChangeType<T>(object[] array)
        {
            List<T> list = new List<T>();
            
            foreach (object o in array)
            {
                list.Add((T) o);
            }

            return list.ToArray();
        }
    }
}