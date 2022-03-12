// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AdvancedAutoNuke
{
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;
        private CoroutineHandle nukeCoroutine;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            Warhead.IsLocked = false;
            nukeCoroutine = Timing.RunCoroutine(NukeCoroutine(), Segment.FixedUpdate);
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundEnded(RoundEndedEventArgs)"/>
        public void OnRoundEnded(RoundEndedEventArgs ev) => KillCoroutine();

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRestartingRound"/>
        public void OnRestartingRound() => KillCoroutine();

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnWaitingForPlayers"/>
        public void OnWaitingForPlayers() => KillCoroutine();

        private void KillCoroutine()
        {
            if (nukeCoroutine.IsRunning)
                Timing.KillCoroutines(nukeCoroutine);
        }

        private IEnumerator<float> NukeCoroutine()
        {
            yield return Timing.WaitForSeconds(plugin.Config.Time);

            if (Warhead.IsDetonated)
                yield break;

            Cassie.Message(plugin.Config.PreCassie);
            Map.Broadcast(plugin.Config.PreBroadcast);

            yield return Timing.WaitForSeconds(plugin.Config.IntervalTime);

            Warhead.IsLocked = plugin.Config.IsLocked;
            Cassie.Message(plugin.Config.Cassie);
            Map.Broadcast(plugin.Config.Broadcast);

            if (Warhead.IsInProgress || Warhead.IsDetonated)
                yield break;

            Warhead.Start();
        }
    }
}