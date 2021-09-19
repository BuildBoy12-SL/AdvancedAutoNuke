// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AdvancedAutoNuke
{
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the time, in seconds, until the pre-announcements play.
        /// </summary>
        [Description("The time, in seconds, until the pre-announcements play.")]
        public int Time { get; set; } = 1200;

        /// <summary>
        /// Gets or sets the broadcast to display on the pre-announcement stage.
        /// </summary>
        [Description("The broadcast to display on the pre-announcement stage.")]
        public Broadcast PreBroadcast { get; set; } = new Broadcast("The <color=red>AutoNuke</color> will enable in 30 seconds!", 5);

        /// <summary>
        /// Gets or sets the cassie announcement to play on the pre-announcement stage.
        /// </summary>
        [Description("The cassie announcement to play on the pre-announcement stage.")]
        public string PreCassie { get; set; } = "The Alpha . Warhead Automatic detonation sequence will start in t-minus 30 seconds";

        /// <summary>
        /// Gets or sets the time, in seconds, after the pre-announcements play that the warhead starts.
        /// </summary>
        [Description("The time, in seconds, after the pre-announcements play that the warhead starts.")]
        public int IntervalTime { get; set; } = 30;

        /// <summary>
        /// Gets or sets a value indicating whether the auto nuke should be locked while counting down.
        /// </summary>
        [Description("Whether the auto nuke should be locked while counting down.")]
        public bool IsLocked { get; set; } = true;

        /// <summary>
        /// Gets or sets the broadcast to display when the auto nuke starts.
        /// </summary>
        [Description("The broadcast to display when the auto nuke starts.")]
        public Broadcast Broadcast { get; set; } = new Broadcast("The <color=red>AutoNuke</color> is now enabled!\nIt can not be disabled!", 5);

        /// <summary>
        /// Gets or sets the cassie announcement to play when the auto nuke starts.
        /// </summary>
        [Description("The cassie announcement to play when the auto nuke starts.")]
        public string Cassie { get; set; } = "The Alpha . Warhead Automatic detonation sequence has initiated . . detonation can not be disengaged";
    }
}