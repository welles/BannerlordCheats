using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using System.Linq;
using BannerlordCheats.Extensions;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class PartyHealthRegeneration
    {
        private static int? LastSet = null;

        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnApplicationTick(float dt)
        {
            try
            {
                if (Mission.Current != null
                    && Mission.Current.PlayerTeam != null
                    && MBCommon.IsPaused != true
                    && BannerlordCheatsSettings.Instance?.PartyHealthRegeneration > 0f)
                {
                    var now = DateTime.Now.Second;

                    if (PartyHealthRegeneration.LastSet == null || now != PartyHealthRegeneration.LastSet)
                    {
                        PartyHealthRegeneration.LastSet = now;

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

                            if (health < maxHealth)
                            {
                                var regen = (BannerlordCheatsSettings.Instance.PartyHealthRegeneration / maxHealth) * 100;
                                var newHealth = (float)Math.Round(health + regen);

                                agent.Health = Math.Min(maxHealth, newHealth);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyHealthRegeneration));
            }
        }
    }
}
