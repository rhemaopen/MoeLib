﻿// ***********************************************************************
// Project          : MoeLib
// File             : IMoeGrain.cs
// Created          : 2015-11-25  1:38 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  2:24 PM
// ***********************************************************************
// <copyright file="IMoeGrain.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;

namespace MoeLib.Orleans
{
    /// <summary>
    ///     Interface IMoeGrain
    /// </summary>
    public interface IMoeGrain : IGrain
    {
        /// <summary>
        ///     String representation of grain's SiloIdentity including type and primary key.
        /// </summary>
        string IdentityString { get; }

        /// <summary>
        ///     A unique identifier for the current silo.
        ///     There is no semantic content to this string, but it may be useful for logging.
        /// </summary>
        string RuntimeIdentity { get; }

        /// <summary>
        ///     Get a previously registered reminder or registers a new persistent, reliable reminder to send regular notifications (reminders) to the MoeGrainBase.
        ///     The MoeGrainBase must implement the <c>Orleans.IRemindable</c> interface, and reminders for this MoeGrainBase will be sent to the <c>ReceiveReminder</c> callback method.
        ///     If the current MoeGrainBase is deactivated when the timer fires, a new activation of this MoeGrainBase will be created to receive this reminder.
        ///     If an existing reminder with the same name already exists, that reminder will be overwritten with this new reminder.
        ///     Reminders will always be received by one activation of this MoeGrainBase, even if multiple activations exist for this MoeGrainBase.
        /// </summary>
        /// <param name="reminderName">Name of this reminder</param>
        /// <param name="dueTime">Due time for this reminder</param>
        /// <param name="period">Frequence period for this reminder</param>
        /// <returns>Promise for Reminder handle.</returns>
        Task<IGrainReminder> GetOrRegisterReminder(string reminderName, TimeSpan dueTime, TimeSpan period);

        /// <summary>
        ///     Unregisters a previously registered reminder or do nothing if the reminder has not been registered.
        /// </summary>
        /// <param name="reminderName">Name of the reminder to unregister.</param>
        /// <returns>Completion promise for this operation.</returns>
        Task UnregisterReminder(string reminderName);
    }
}