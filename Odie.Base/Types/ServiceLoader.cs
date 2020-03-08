using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ServiceLoader
    {
        public static ServiceLoader Current = new ServiceLoader();

        private Dictionary<Type, object> Dictionary = new Dictionary<Type, object>();

        public void Register<T>(T t)
        {
            Dictionary.Add(typeof(T), t);
        }

        public void Register(object instance, Type registerAs)
        {
            Dictionary.Add(registerAs, instance);
        }

        public bool Has(Type type)
        {
            return Dictionary.Keys.Contains(type);
        }

        public void Register(Type type)
        {
            ConstructorInfo ctor = type.GetConstructors().OrderBy(x => x.GetParameters()).First();
            ParameterInfo[] parameters = ctor.GetParameters();
            List<object> objectParameters = new List<object>();
            
            foreach (ParameterInfo parameter in parameters)
            {
                Type parameterType = parameter.ParameterType;
                
                if (parameterType.IsValueType)
                {
                    objectParameters.Add(Activator.CreateInstance(parameterType));
                }

                else
                {
                    if (Has(parameterType))
                    {
                        objectParameters.Add(Resolve(parameterType));
                    }

                    else
                    {
                        Register(parameterType);
                        objectParameters.Add(Resolve(parameterType));
                    }
                }
            }

            object instance = ctor.Invoke(objectParameters.ToArray());
            
            Register(instance, type);
        }

        public void Register<T>()
        {
            Register(typeof(T));
        }

        public object Resolve(Type type)
        {
            return Dictionary[type];
        }

        public T Resolve<T>()
        {
            return (T) Dictionary[typeof(T)];
        }

        public void Clear()
        {
            Dictionary.Clear();
        }
    }
}