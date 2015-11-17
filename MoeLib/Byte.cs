﻿// ***********************************************************************
// Project          : MoeLib
// File             : Byte.cs
// Created          : 2015-08-13  3:30 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-09-13  7:05 PM
// ***********************************************************************
// <copyright file="Byte.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Text;

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions of <see cref="System.Byte" /> types.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        ///     Gets ASCII string of specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(this byte value)
        {
            return ByteUtility.Ascii(value);
        }

        /// <summary>
        ///     Gets ASCII string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(this byte[] value)
        {
            return ByteUtility.Ascii(value);
        }

        /// <summary>
        ///     Gets the value of ASCII string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfAscii(this string value)
        {
            return ByteUtility.GetBytesOfAscii(value);
        }

        /// <summary>
        ///     Gets the value of unicode string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUnicode(this string value)
        {
            return ByteUtility.GetBytesOfUnicode(value);
        }

        /// <summary>
        ///     Gets the value of Utf8 string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUtf8(this string value)
        {
            return ByteUtility.GetBytesOfUtf8(value);
        }

        /// <summary>
        ///     Hexadecimals the specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Hex(this byte value)
        {
            return ByteUtility.Hex(value);
        }

        /// <summary>
        ///     Hexadecimals the specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Hex(this byte[] value)
        {
            return ByteUtility.Hex(value);
        }

        /// <summary>
        ///     Gets Unicode string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Unicode(this byte[] value)
        {
            return ByteUtility.Unicode(value);
        }

        /// <summary>
        ///     Gets Utf8 string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Utf8(this byte[] value)
        {
            return ByteUtility.Utf8(value);
        }
    }

    /// <summary>
    ///     Utilities for working with <see cref="System.Byte" /> type.
    /// </summary>
    public static class ByteUtility
    {
        /// <summary>
        ///     Gets ASCII string of specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(byte value)
        {
            return Encoding.ASCII.GetString(new[] { value });
        }

        /// <summary>
        ///     Gets ASCII string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(byte[] value)
        {
            if (value == null)
                return null;
            value = value.FixBom();
            return Encoding.ASCII.GetString(value);
        }

        /// <summary>
        ///     Gets the value of ASCII string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfAscii(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        /// <summary>
        ///     Gets the value of unicode string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUnicode(string value)
        {
            return Encoding.Unicode.GetBytes(value);
        }

        /// <summary>
        ///     Gets the value of Utf8 string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUtf8(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        ///     Hexadecimals the specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Hex(byte value)
        {
            return value.ToString("x2").ToUpperInvariant();
        }

        /// <summary>
        ///     Hexadecimals the specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Hex(byte[] value)
        {
            if (value == null)
                return "";

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
                stringBuilder.Append(value[i].Hex());

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Gets Unicode string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Unicode(byte[] value)
        {
            return value == null ? null : Encoding.Unicode.GetString(value);
        }

        /// <summary>
        ///     Gets Utf8 string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Utf8(byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        /// <summary>
        ///     Fixes the bom.
        /// </summary>
        /// <param name="valueToFix">The value to fix.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] FixBom(this byte[] valueToFix)
        {
            //see BOM - Byte Order Mark : http://en.wikipedia.org/wiki/Byte_order_mark
            //    http://www.verious.com/qa/-239-187-191-characters-appended-to-the-beginning-of-each-file/
            //    http://social.msdn.microsoft.com/Forums/en-US/8956758d-9814-4bd4-9812-e82903640b2f/recieving-239187191-character-symbols-when-loading-text-files-not-containing-them
            if (valueToFix != null && valueToFix.Length > 3 && (valueToFix[0] == '\xEF' && valueToFix[1] == '\xBB' && valueToFix[2] == '\xBF'))
                return valueToFix.Removevalue(2);

            return valueToFix;
        }

        /// <summary>
        ///     Removes the value.
        /// </summary>
        /// <param name="originalvalue">The original value.</param>
        /// <param name="removeFrom">The remove from.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] Removevalue(this byte[] originalvalue, uint removeFrom)
        {
            if (originalvalue.Length > removeFrom)
            {
                long newSize = originalvalue.Length - removeFrom - 1;
                byte[] value = new byte[newSize];
                Array.Copy(originalvalue, removeFrom + 1, value, 0, newSize);
                return value;
            }

            return new byte[0];
        }
    }
}