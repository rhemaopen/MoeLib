// ***********************************************************************
// Project          : MoeLib
// File             : DateTime.cs
// Created          : 2015-03-14  4:14 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-08-12  9:03 AM
// ***********************************************************************
// <copyright file="DateTime.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions of <see cref="System.DateTime" /> type.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Durations to now.
        /// </summary>
        /// <param name="startDateTime">The start date time.</param>
        /// <returns>TimeSpan.</returns>
        public static TimeSpan DurationToNow(this DateTime startDateTime)
        {
            return (DateTime.Now - startDateTime);
        }

        /// <summary>
        ///     Gets the JS datetime of the specified date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long JSDate(this DateTime dateTime)
        {
            return DateTimeUtility.GetJSDate(dateTime);
        }

        /// <summary>
        ///     Gets the unix timestamp of the specified date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.Int64.</returns>
        public static long UnixTimestamp(this DateTime dateTime)
        {
            return DateTimeUtility.GetUnixTimestamp(dateTime);
        }

        /// <summary>
        ///     Gets the UTC of the specified date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime Utc(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime();
        }
    }

    /// <summary>
    ///     Utilities for working with <see cref="System.DateTime" /> types.
    /// </summary>
    public static class DateTimeUtility
    {
        /// <summary>
        ///     The ticks of 1970
        /// </summary>
        private const long EPOCH_TICKS = 621355968000000000;

        /// <summary>
        ///     The file time offset
        /// </summary>
        private const long FILE_TIME_OFFSET = 504911232000000000;

        /// <summary>
        ///     The datetime maximum value minus one day
        /// </summary>
        private static readonly DateTime MaxValueMinusOneDay = DateTime.MaxValue.AddDays(-1);

        /// <summary>
        ///     The datetime minimum value plus one day
        /// </summary>
        private static readonly DateTime MinValuePlusOneDay = DateTime.MinValue.AddDays(1);

        /// <summary>
        ///     Gets the china standard time zone.
        /// </summary>
        /// <value>The china standard time zone.</value>
        public static TimeZoneInfo ChinaStandardTimeZone { get; } = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");

        /// <summary>
        ///     Converts to local time.
        /// </summary>
        /// <param name="utcTime">The UTC time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ConvertToLocalTime(DateTime utcTime)
        {
            if (utcTime < MinValuePlusOneDay)
            {
                return DateTime.MinValue;
            }

            return utcTime > MaxValueMinusOneDay ? DateTime.MaxValue : utcTime.ToLocalTime();
        }

        /// <summary>
        ///     Converts to universal time.
        /// </summary>
        /// <param name="localTime">The local time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ConvertToUniversalTime(DateTime localTime)
        {
            if (localTime < MinValuePlusOneDay)
            {
                return DateTime.MinValue;
            }

            return localTime > MaxValueMinusOneDay ? DateTime.MaxValue : localTime.ToUniversalTime();
        }

        /// <summary>
        ///     Gets the UTC from the file time.
        /// </summary>
        /// <param name="fileTime">The file time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromFileTime(long fileTime)
        {
            long universalTicks = fileTime + FILE_TIME_OFFSET;
            // Dev10 733288: Caching: behavior change for CacheDependency when using UseMemoryCache=1
            // ObjectCacheHost converts DateTime to a DateTimeOffset, and the conversion requires
            // that DateTimeKind be set correctly
            return new DateTime(universalTicks, DateTimeKind.Utc);
        }

        /// <summary>
        ///     Gets the UTC from the js date string.
        /// </summary>
        /// <param name="dateMillisecondsAfter1970">The date milliseconds after1970.</param>
        /// <returns>UTC DateTime.</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static DateTime FromJSDate(long dateMillisecondsAfter1970)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddMilliseconds(dateMillisecondsAfter1970);
        }

        /// <summary>
        ///     Froms the string.
        /// </summary>
        /// <param name="value">The date string.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromString(string value)
        {
            return DateTime.Parse(value);
        }

        /// <summary>
        ///     Froms the ticks.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromTicks(int ticks)
        {
            return new DateTime(ticks);
        }

        /// <summary>
        ///     Froms the ticks.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns>DateTime.</returns>
        public static DateTime FromTicks(long ticks)
        {
            return new DateTime(ticks);
        }

        /// <summary>
        ///     Gets the UTC from the js date string.
        /// </summary>
        /// <param name="timeStamp">The time stamp.</param>
        /// <returns>DateTime.</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static DateTime FromUnixTimestamp(long timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(timeStamp);
        }

        /// <summary>
        ///     Gets the js date.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>System.Int64.</returns>
        public static long GetJSDate(DateTime time)
        {
            DateTime utc = time.ToUniversalTime();
            return (utc.Ticks - EPOCH_TICKS) / 10000;
        }

        /// <summary>
        ///     Gets the js date of now.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static long GetJSDate()
        {
            DateTime utc = DateTime.UtcNow;
            return GetJSDate(utc);
        }

        /// <summary>
        ///     Gets the unix time stamp.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>System.Int64.</returns>
        public static long GetUnixTimestamp(DateTime time)
        {
            DateTime utc = time.ToUniversalTime();
            return (utc.Ticks - EPOCH_TICKS) / 10000000;
        }

        /// <summary>
        ///     Gets the unix time stamp of now.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public static long GetUnixTimestamp()
        {
            DateTime utc = DateTime.UtcNow;
            return GetUnixTimestamp(utc);
        }

        /// <summary>
        ///     Determines whether [is in the day] [the specified date].
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="date">The date.</param>
        /// <returns><c>true</c> if [is in the day] [the specified date]; otherwise, <c>false</c>.</returns>
        public static bool IsInTheDay(this DateTime time, DateTime date)
        {
            return time >= date.Date && time < date.Date.AddDays(1);
        }

        /// <summary>
        ///     To the china standard time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToChinaStandardTime(this DateTime time)
        {
            time = time.ToUniversalTime().AddHours(8);
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Millisecond, DateTimeKind.Local);
        }

        /// <summary>
        ///     To the datetime.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDateTime(this int ticks)
        {
            return ((long)ticks).ToDateTime();
        }

        /// <summary>
        ///     To the datetime.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns>DateTime.</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static DateTime ToDateTime(this long ticks)
        {
            return new DateTime(ticks);
        }

        /// <summary>
        ///     To the UTC from file time.
        /// </summary>
        /// <param name="fileTime">The file time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDateTimeFromFileTime(this long fileTime)
        {
            return FromFileTime(fileTime);
        }

        /// <summary>
        ///     To the UTC from js date.
        /// </summary>
        /// <param name="dateMillisecondsAfter1970">The date milliseconds after1970.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDateTimeFromJSDate(this long dateMillisecondsAfter1970)
        {
            return FromJSDate(dateMillisecondsAfter1970);
        }

        /// <summary>
        ///     To the UTC from unix timestamp.
        /// </summary>
        /// <param name="timeStamp">The timestamp.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDateTimeFromUnixTimestamp(this long timeStamp)
        {
            return FromUnixTimestamp(timeStamp);
        }
    }
}