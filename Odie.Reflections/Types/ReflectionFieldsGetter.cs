using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie.Reflections
{
    public class ReflectionFieldsGetter : IReflectionFieldsGetter
    {
        public IReflectionFieldGenerator Generator;

        public ReflectionFieldsGetter(IReflectionFieldGenerator generator)
        {
            Generator = generator;
        }

        public IEnumerable<ReflectionField> Get(Type type, MemberType memberTypes = MemberType.PROPERTY)
        {
            if (memberTypes.HasFlag(MemberType.FIELD))
            {
                FieldInfo[] fields = type.GetFields();

                foreach (FieldInfo fieldInfo in fields)
                {
                    yield return Generator.Generate(fieldInfo);
                }
            }
            
            if (memberTypes.HasFlag(MemberType.PROPERTY))
            {
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    yield return Generator.Generate(property);
                }
            }
        }
    }
}