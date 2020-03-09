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

            Dictionary.Add(type, null);

            foreach (Type @interface in type.GetInterfaces())
            {
                Dictionary.Add(@interface, null);
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

            RegisterAs(type, null);
        }

        public void RegisterType(Type type)
        {
            RegisterAs(type, null);
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
            foreach (Type @interface in typeof(T).GetInterfaces())
            {
                Dictionary.Add(@interface, null);
            }
        }

        public void RegisterInterfaces(Type type)
        {
            foreach (Type @interface in type.GetInterfaces())
            {
                Dictionary.Add(@interface, null);
            }
        }
    }

    public partial class ServiceLoader
    {
        public bool Has(Type infoType)
        {
            return Dictionary.Keys.Contains(infoType);
        }

        public bool HasValue(Type infoType)
        {
            return Dictionary[infoType] != null;
        }
    }

    public partial class ServiceLoader
    {
        public T Resolve<T>()
        {
            Type infoType = typeof(T);
            
            if (HasValue(infoType))
            {
                return (T) Dictionary[infoType];
            }

            object instance = InstancesCreator.Current.CreateInstance(infoType, this);

            Dictionary[infoType] = instance;

            return (T) instance;
        }

        public object Resolve(Type type)
        {
            if (HasValue(type))
            {
                return Dictionary[type];
            }

            object instance = InstancesCreator.Current.CreateInstance(type, this);

            Dictionary[type] = instance;

            return instance;
        }
    }

    public partial class ServiceLoader
    {
        public static ServiceLoader Current = new ServiceLoader();
    }
}