// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AdvancedAutoNuke
{
    using System;
    using Exiled.API.Features;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            ServerHandlers.RoundStarted += eventHandlers.OnRoundStarted;
            ServerHandlers.RoundEnded += eventHandlers.OnRoundEnded;
            ServerHandlers.RestartingRound += eventHandlers.OnRestartingRound;
            ServerHandlers.WaitingForPlayers += eventHandlers.OnWaitingForPlayers;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandlers.RoundStarted -= eventHandlers.OnRoundStarted;
            ServerHandlers.RoundEnded -= eventHandlers.OnRoundEnded;
            ServerHandlers.RestartingRound -= eventHandlers.OnRestartingRound;
            ServerHandlers.WaitingForPlayers -= eventHandlers.OnWaitingForPlayers;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}