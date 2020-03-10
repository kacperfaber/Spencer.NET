using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public partial class ServiceLoader
    {
        public Dictionary<Type, object> Dictionary;
        public List<Assembly> Assemblies;
        
        // options like AUTO_VALUES TODO
        
        // mulitinstance

        public ServiceLoader()
        {
            Dictionary = new Dictionary<Type, object>();
            Assemblies = new List<Assembly>();
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
            if (!Has(type))
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
                RegisterAs(@interface, null);
            }
        }

        public void RegisterInterfaces(Type type)
        {
            foreach (Type @interface in type.GetInterfaces())
            {
                RegisterAs(@interface, null);
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
            return Has(infoType) && Dictionary[infoType] != null;
        }
    }

    public partial class ServiceLoader
    {
        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            if (HasValue(type))
            {
                return Dictionary[type];
            }

            Assembly typeAssembly = type.Assembly;
            
            if (!Assemblies.Contains(typeAssembly))
            {
                Current.RegisterAssembly(typeAssembly);
            }

            if (!HasValue(type))
            {
                object instance = InstancesCreator.Current.CreateInstance(type, this);
                Dictionary[type] = instance;
                return instance;
            }

            return Dictionary[type];
        }
    }

    public partial class ServiceLoader
    {
        public static ServiceLoader Current = new ServiceLoader();
    }
}