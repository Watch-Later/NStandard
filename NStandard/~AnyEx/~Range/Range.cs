﻿using System;
using System.Collections.Generic;

namespace NStandard
{
    public static class RangeEx
    {
        public static IEnumerable<DateTime> Create(DateTime start, int length, DateRangeType type)
        {
            if (type is DateRangeType.Unset) throw new ArgumentException("Please specify the DateRangeType.", nameof(type));

            var value = start;
            for (int i = 0; i < length; i++)
            {
                yield return value;
                switch (type)
                {
                    case DateRangeType.Year: value = value.AddYears(1); break;
                    case DateRangeType.Month: value = value.AddMonths(1); break;
                    case DateRangeType.Day: value = value.AddDays(1); break;
                    case DateRangeType.Hour: value = value.AddHours(1); break;
                    case DateRangeType.Minute: value = value.AddMinutes(1); break;
                    case DateRangeType.Second: value = value.AddSeconds(1); break;
                }
            }
        }

        public static IEnumerable<DateTime> CreateRange(DateTime start, DateTime end, DateRangeType type)
        {
            if (type is DateRangeType.Unset) throw new ArgumentException("Please specify the DateRangeType.", nameof(type));

            var value = start;
            while (value <= end)
            {
                yield return value;
                switch (type)
                {
                    case DateRangeType.Year: value = value.AddYears(1); break;
                    case DateRangeType.Month: value = value.AddMonths(1); break;
                    case DateRangeType.Day: value = value.AddDays(1); break;
                    case DateRangeType.Hour: value = value.AddHours(1); break;
                    case DateRangeType.Minute: value = value.AddMinutes(1); break;
                    case DateRangeType.Second: value = value.AddSeconds(1); break;
                }
            }
        }

        public static IEnumerable<int> Create(int start, int length)
        {
            for (int i = 0; i < length; i++) yield return start + i;
        }

        public static IEnumerable<int> Create(int start, int length, Func<int, int> iterator)
        {
            var value = start;
            for (int i = 0; i < length; i++)
            {
                yield return value;
                value = iterator(value);
            }
        }

        public static IEnumerable<int> CreateRange(int start, int end)
        {
            var value = start;
            while (value <= end)
            {
                yield return value;
                value++;
            }
        }

        public static IEnumerable<int> CreateRange(int start, int end, Func<int, int> iterator)
        {
            var value = start;
            while (value <= end)
            {
                yield return value;
                value = iterator(value);
            }
        }

    }
}
