using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public partial class ServiceLoader
    {
        public Dictionary<Type, object> Dictionary;

        public ServiceLoader()
        {
            Dictionary = new Dictionary<Type, object>();
        }

        public void Register<T>()
        {
            Type type = typeof(T);

            object instance = InstancesCreator.Current.CreateInstance(type, this);
            Dictionary.Add(type, instance);

            foreach (Type @interface in type.GetInterfaces())
            {
                Dictionary.Add(@interface, instance);
            }
        }

        public void Register<TKey, TValue>()
        {
            Dictionary.Add(typeof(TKey), InstancesCreator.Current.CreateInstance(typeof(TValue), this));
        }

        public void RegisterAs(Type type, object instance)
        {
            Dictionary.Add(type, instance);
        }

        public void RegisterType<T>()
        {
            Type type = typeof(T);
            object instance = InstancesCreator.Current.CreateInstance(type, this);

            RegisterAs(type, instance);
        }

        public void RegisterType(Type type)
        {
            object instance = InstancesCreator.Current.CreateInstance(type, this);

            RegisterAs(type, instance);
        }

        public void RegisterValue(Type type, object value)
        {
            RegisterAs(type, value);
        }

        public void RegisterValue<T>(object value)
        {
            RegisterAs(typeof(T), value);
        }

        public void RegisterInterfaces<T>()
        {
            object instance = InstancesCreator.Current.CreateInstance(typeof(T), this);

            foreach (Type @interface in typeof(T).GetInterfaces())
            {
                Dictionary.Add(@interface, instance);
            }
        }

        public void RegisterInterfaces(Type type)
        {
            object instance = InstancesCreator.Current.CreateInstance(type, this);

            foreach (Type @interface in type.GetInterfaces())
            {
                Dictionary.Add(@interface, instance);
            }
        }
    }

    public partial class ServiceLoader
    {
        public bool Has(Type infoType)
        {
            return Dictionary.Keys.Contains(infoType);
        }
    }

    public partial class ServiceLoader
    {
        public T Resolve<T>()
        {
            return (T) Dictionary[typeof(T)];
        }

        public object Resolve(Type type)
        {
            return Dictionary[type];
        }
    }

    public partial class ServiceLoader
    {
        public static ServiceLoader Current = new ServiceLoader();
    }
}