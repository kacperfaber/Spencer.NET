﻿namespace Odie
{
    public class Range
    {
        public int From { get; set; }

        public int To { get; set; }

        public Range(int @from, int to)
        {
            From = @from;
            To = to;
        }
    }
}