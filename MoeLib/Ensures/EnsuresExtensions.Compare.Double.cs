﻿// ***********************************************************************
// Assembly         : MoeEnsure
// Author           : Siqi Lu
// Created          : 2015-03-15  2:52 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-17  12:29 AM
// ***********************************************************************
// <copyright file="EnsuresExtensions.Compare.Double.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions of Ensures utility for the <see cref="System.Double" />.
    /// </summary>
    public static partial class EnsuresExtensions
    {
        /// <summary>
        ///     Checks whether the given value is equal to the specified <paramref name="value" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The valid value to compare with.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsEqualTo(this Ensures<double> ensures, double value)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return ensures.That(v => v == value);
        }

        /// <summary>
        ///     Checks whether the given value is greater or equal to the specified <paramref name="minValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsGreaterOrEqual(this Ensures<double> ensures, double minValue)
        {
            return ensures.That(v => v >= minValue);
        }

        /// <summary>
        ///     Checks whether the given value is greater than the specified <paramref name="minValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsGreaterThan(this Ensures<double> ensures, double minValue)
        {
            return ensures.That(v => v > minValue);
        }

        /// <summary>
        ///     Checks whether the given value is infinity.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsInfinity(this Ensures<double> ensures)
        {
            return ensures.That(v => double.IsInfinity(v));
        }

        /// <summary>
        ///     Checks whether the given value is between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values).
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsInRange(this Ensures<double> ensures, double minValue, double maxValue)
        {
            return ensures.That(v => v >= minValue && v <= maxValue);
        }

        /// <summary>
        ///     Checks whether the given value is smaller or equal to the specified <paramref name="maxValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The highest valid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsLessOrEqual(this Ensures<double> ensures, double maxValue)
        {
            return ensures.That(v => v <= maxValue);
        }

        /// <summary>
        ///     Checks whether the given value is less than the specified <paramref name="maxValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsLessThan(this Ensures<double> ensures, double maxValue)
        {
            return ensures.That(v => v < maxValue);
        }

        /// <summary>
        ///     Checks whether the given value is a valid number.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNaN(this Ensures<double> ensures)
        {
            return ensures.That(v => double.IsNaN(v));
        }

        /// <summary>
        ///     Checks whether the given value is negative infinity.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNegativeInfinity(this Ensures<double> ensures)
        {
            return ensures.That(v => double.IsNegativeInfinity(v));
        }

        /// <summary>
        ///     Checks whether the given value is unequal to the specified <paramref name="value" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="value">The invalid value to compare with.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotEqualTo(this Ensures<double> ensures, double value)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return ensures.Not(v => v == value);
        }

        /// <summary>
        ///     Checks whether the given value is not greater or equal to the specified <paramref name="maxValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest invalid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotGreaterOrEqual(this Ensures<double> ensures, double maxValue)
        {
            return ensures.That(v => v < maxValue);
        }

        /// <summary>
        ///     Checks whether the given value is not greater than the specified <paramref name="maxValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="maxValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotGreaterThan(this Ensures<double> ensures, double maxValue)
        {
            return ensures.That(v => v <= maxValue);
        }

        /// <summary>
        ///     Checks whether the given value is not infinity.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotInfinity(this Ensures<double> ensures)
        {
            return ensures.Not(v => double.IsInfinity(v));
        }

        /// <summary>
        ///     Checks whether the given value is not between <paramref name="minValue" /> and
        ///     <paramref name="maxValue" /> (including those values).
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest invalid value.</param>
        /// <param name="maxValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotInRange(this Ensures<double> ensures, double minValue, double maxValue)
        {
            return ensures.That(v => v > maxValue || v < minValue);
        }

        /// <summary>
        ///     Checks whether the given value is not smaller or equal to the specified <paramref name="minValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The highest invalid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotLessOrEqual(this Ensures<double> ensures, double minValue)
        {
            return ensures.That(v => v > minValue);
        }

        /// <summary>
        ///     Checks whether the given value is not less than the specified <paramref name="minValue" />.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <param name="minValue">The lowest valid value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotLessThan(this Ensures<double> ensures, double minValue)
        {
            return ensures.That(v => v >= minValue);
        }

        /// <summary>
        ///     Checks whether the given value is a not valid number.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotNaN(this Ensures<double> ensures)
        {
            return ensures.Not(v => double.IsNaN(v));
        }

        /// <summary>
        ///     Checks whether the given value is not negative infinity.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotNegativeInfinity(this Ensures<double> ensures)
        {
            return ensures.Not(v => double.IsNegativeInfinity(v));
        }

        /// <summary>
        ///     Checks whether the given value is not positive infinity.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsNotPositiveInfinity(this Ensures<double> ensures)
        {
            return ensures.Not(v => double.IsPositiveInfinity(v));
        }

        /// <summary>
        ///     Checks whether the given value is positive infinity.
        /// </summary>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be checked.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<double> IsPositiveInfinity(this Ensures<double> ensures)
        {
            return ensures.That(v => double.IsPositiveInfinity(v));
        }
    }
}
