﻿namespace Spencer.NET
{
    public class ServiceFlag
    {
        public string Name;
        public object Value;
        public IMember Member;

        public ServiceFlag(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}