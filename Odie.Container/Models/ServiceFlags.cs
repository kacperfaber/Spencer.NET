using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ServiceFlags : List<ServiceFlag>
    {
        public bool HasFlag(string name)
        {
            return this.SingleOrDefault(x => x.Name == name) != null;
        }

        public bool HasFlag(ServiceFlag flag)
        {
            return this.SingleOrDefault(x => x == flag) != null;
        }

        public bool HasFlag(string name, object value)
        {
            return this.Where(x => x.Name == name).SingleOrDefault(x => x.Value == value) != null;
        }

        public ServiceFlag GetFlag(string name)
        {
            return this.Single(x => x.Name == name);
        }

        public void AddFlag(string name, object value)
        {
            Add(new ServiceFlag(name, value));
        }

        public void AddFlag(string name, object value, MemberInfo parent)
        {
            Add(new ServiceFlag(name, value) {Parent = parent});
        }

        public void RemoveFlag(string name)
        {
            Remove(this.Single(x => x.Name == name));
        }
        
        public static ServiceFlags CreateNew() => new ServiceFlags();
    }
}