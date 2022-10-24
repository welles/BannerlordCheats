using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using System.Linq;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class PartyHealthRegeneration
    {
        private static int? _lastSet;

        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (!(Mission.Current is { PlayerTeam: { } })
                    || MBCommon.IsPaused
                    || !(BannerlordCheatsSettings.Instance?.PartyHealthRegeneration > 0f)) return;
                var now = DateTime.Now.Second;

                if (now == _lastSet) return;
                _lastSet = now;

                var playerPartyAgents = Mission.Current.PlayerTeam.ActiveAgents
                    .Where(x => x.Health > 0
                                && !x.IsPlayer()
                                && x.Origin.TryGetParty(out var party)
                                && party.IsPlayerParty())
                    .ToArray();

                foreach (var agent in playerPartyAgents)
                {
                    var health = agent.Health;
                    var maxHealth = agent.HealthLimit;

                    if (!(health < maxHealth)) continue;
                    var regen = (BannerlordCheatsSettings.Instance.PartyHealthRegeneration / maxHealth) * 100;
                    var newHealth = (float)Math.Round(health + regen);

                    agent.Health = Math.Min(maxHealth, newHealth);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyHealthRegeneration));
            }
        }
    }
}
