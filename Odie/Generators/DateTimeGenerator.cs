using System;
using System.Globalization;
using System.Linq;

namespace Odie
{
    public class DateTimeGenerator : IValueGenerator
    {
        public object Generate(object parameters, Type parametersType, Type[] exceptedType, out Type valueType)
        {
            RandomGenerator random = StaticContainer.Current.Resolve<RandomGenerator>();

            if (parametersType == typeof(DateTimeParameter))
            {
                DateTimeParameter parameter = parameters as DateTimeParameter;
                
                if (exceptedType.First() == typeof(DateTime))
                {
                    valueType = typeof(DateTime);
                    return GenerateDateTime(parameter.Kind == DateTimeKind.FUTURE);
                }

                if (exceptedType.First() == typeof(string))
                {
                    valueType = typeof(string);
                    return GenerateDateTime(parameter.Kind == DateTimeKind.FUTURE).ToString(DateTimeFormatInfo.CurrentInfo);
                }
                
                if (exceptedType.First() == typeof(ulong))
                {
                    valueType = typeof(ulong);
                    return new TimeSpan(GenerateDateTime(parameter.Kind == DateTimeKind.FUTURE).Ticks).TotalSeconds;
                }

                else
                {
                    valueType = typeof(DateTime);
                    return GenerateDateTime(parameter.Kind == DateTimeKind.FUTURE);
                }
            }
            
            throw new ArgumentException();
        }

        DateTime GenerateDateTime(bool upper)
        {
            RandomGenerator random = StaticContainer.Current.Resolve<RandomGenerator>();

            if (upper)
            {
                return DateTime.Now
                    .AddYears(random.GenerateInt(0, 10))
                    .AddMonths(random.GenerateInt(0, 12))
                    .AddDays(random.GenerateInt(0, 30))
                    .AddHours(random.GenerateInt(0, 24))
                    .AddMinutes(random.GenerateInt(0, 60))
                    .AddSeconds(random.GenerateInt(0, 60));
            }

            else
            {
                return DateTime.Now
                    .Subtract(TimeSpan.FromDays(random.GenerateInt(0, 3000)))
                    .Subtract(TimeSpan.FromHours(random.GenerateInt(0, 24)))
                    .Subtract(TimeSpan.FromMinutes(random.GenerateInt(0, 60)))
                    .Subtract(TimeSpan.FromSeconds(random.GenerateInt(0, 60)));
            }
        }
    }
}