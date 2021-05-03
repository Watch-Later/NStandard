﻿using System;
using System.ComponentModel;
using System.Linq;

namespace NStandard
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class XDateTime
    {
        /// <summary>
        /// Gets a past day for the specified day of week.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="includeCurrentDay"></param>
        /// <returns></returns>
        public static DateTime PastDay(this DateTime @this, DayOfWeek dayOfWeek, bool includeCurrentDay = false)
        {
            var days = dayOfWeek - @this.DayOfWeek;
            if (!includeCurrentDay && days == 0) return @this.AddDays(-7);
            else return @this.AddDays(CastCycleDays(days, true));
        }

        /// <summary>
        /// Gets a future day for the specified day of week.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="includeCurrentDay"></param>
        /// <returns></returns>
        public static DateTime FutureDay(this DateTime @this, DayOfWeek dayOfWeek, bool includeCurrentDay = false)
        {
            var days = dayOfWeek - @this.DayOfWeek;

            if (!includeCurrentDay && days == 0) return @this.AddDays(7);
            else return @this.AddDays(CastCycleDays(days, false));
        }

        /// <summary>
        /// Gets the number of weeks in a month for the specified date.
        /// (eg. If define Sunday as the fisrt day of the week, its first appearance means week 1, before is week 0.)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="weekStart"></param>
        /// <returns></returns>
        public static int WeekInMonth(this DateTime @this, DayOfWeek weekStart = DayOfWeek.Sunday)
        {
            var day1 = new DateTime(@this.Year, @this.Month, 1, 0, 0, 0, @this.Kind);
            var week0 = PastDay(day1, weekStart, true);

            if (week0.Month == @this.Month) week0 = week0.AddDays(-7);
            return (PastDay(@this, weekStart, true) - week0).Days / 7;
        }

        /// <summary>
        /// Gets the number of weeks in a year for the specified date. 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="weekStart"></param>
        /// <returns></returns>
        public static int Week(this DateTime @this, DayOfWeek weekStart = DayOfWeek.Sunday)
        {
            var day1 = new DateTime(@this.Year, 1, 1, 0, 0, 0, @this.Kind);
            var week0 = PastDay(day1, weekStart, true);

            if (week0.Year == @this.Year) week0 = week0.AddDays(-7);
            return (PastDay(@this, weekStart, true) - week0).Days / 7;
        }

        /// <summary>
        /// Returns the number of milliseconds that have elapsed since 1970-01-01T00:00:00.000Z.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static long ToUnixTimeMilliseconds(this DateTime @this)
        {
            long num = @this.ToUniversalTime().Ticks / 10000;
            return num - 62135596800000L;
        }

        /// <summary>
        /// Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static long ToUnixTimeSeconds(this DateTime @this)
        {
            long num = @this.ToUniversalTime().Ticks / 10000000;
            return num - 62135596800L;
        }

        /// <summary>
        /// Get the start point of the sepecified month.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfYear(this DateTime @this) => new(@this.Year, 1, 1, 0, 0, 0, 0, @this.Kind);

        /// <summary>
        /// Get the start point of the sepecified month.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime @this) => new(@this.Year, @this.Month, 1, 0, 0, 0, 0, @this.Kind);

        /// <summary>
        /// Get the start point of the sepecified day.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime @this) => @this.Date;

        /// <summary>
        /// Get the start point of the sepecified hour.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfHour(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, @this.Hour, 0, 0, 0, @this.Kind);

        /// <summary>
        /// Get the start point of the sepecified minute.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfMinute(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, @this.Hour, @this.Minute, 0, 0, @this.Kind);

        /// <summary>
        /// Get the start point of the sepecified second.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfSecond(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, @this.Hour, @this.Minute, @this.Second, 0, @this.Kind);

        /// <summary>
        /// Get the end point of the sepecified month.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfYear(this DateTime @this) => new(@this.Year, 12, 31, 23, 59, 59, 999, @this.Kind);

        /// <summary>
        /// Get the end point of the sepecified month.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime @this)
        {
            if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(@this.Month))
                return new DateTime(@this.Year, @this.Month, 31, 23, 59, 59, 999, @this.Kind);
            else if (new[] { 4, 6, 9, 11 }.Contains(@this.Month))
                return new DateTime(@this.Year, @this.Month, 30, 23, 59, 59, 999, @this.Kind);
            else
            {
                if (DateTime.IsLeapYear(@this.Year))
                    return new DateTime(@this.Year, @this.Month, 29, 23, 59, 59, 999, @this.Kind);
                else return new DateTime(@this.Year, @this.Month, 28, 23, 59, 59, 999, @this.Kind);
            }
        }

        /// <summary>
        /// Get the end point of the sepecified day.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, 23, 59, 59, 999, @this.Kind);

        /// <summary>
        /// Get the end point of the sepecified hour.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfHour(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, @this.Hour, 59, 59, 999, @this.Kind);

        /// <summary>
        /// Get the end point of the sepecified minute.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfMinute(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, @this.Hour, @this.Minute, 59, 999, @this.Kind);

        /// <summary>
        /// Get the end point of the sepecified second.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfSecond(this DateTime @this) => new(@this.Year, @this.Month, @this.Day, @this.Hour, @this.Minute, @this.Second, 999, @this.Kind);

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of complete years to the value of this instance.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="completeYears"></param>
        /// <returns></returns>
        public static DateTime AddCompleteYears(this DateTime @this, int completeYears)
        {
            var target = @this.AddYears(completeYears);
            if (completeYears > 0 && target.Day < @this.Day) target = target.AddDays(1);
            return target;
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of complete months to the value of this instance.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="completeMonths"></param>
        /// <returns></returns>
        public static DateTime AddCompleteMonths(this DateTime @this, int completeMonths)
        {
            var target = @this.AddMonths(completeMonths);
            if (completeMonths > 0 && target.Day < @this.Day) target = target.AddDays(1);
            return target;
        }

        /// <summary>
        /// Gets the number of milliseconds elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedMilliseconds(this DateTime @this) => (@this - DateTime.MinValue).TotalMilliseconds;

        /// <summary>
        /// Gets the number of seconds elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedSeconds(this DateTime @this) => (@this - DateTime.MinValue).TotalSeconds;

        /// <summary>
        /// Gets the number of minutes elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedMinutes(this DateTime @this) => (@this - DateTime.MinValue).TotalMinutes;

        /// <summary>
        /// Gets the number of hours elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedHours(this DateTime @this) => (@this - DateTime.MinValue).TotalHours;

        /// <summary>
        /// Gets the number of days elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedDays(this DateTime @this) => (@this - DateTime.MinValue).TotalDays;

        /// <summary>
        /// Gets the number of months elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedMonths(this DateTime @this) => DateTimeEx.ExactMonthDiff(DateTime.MinValue, @this);

        /// <summary>
        /// Gets the number of years elapsed from <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double ElapsedYears(this DateTime @this) => DateTimeEx.ExactYearDiff(DateTime.MinValue, @this);

        private static int CastCycleDays(int days, bool isBackward)
        {
            days %= 7;
            if (isBackward) return days > 0 ? days - 7 : days;
            else return days < 0 ? days + 7 : days;
        }

    }
}
