using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using System.Linq;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class PartyHealthRegen
    {
        private static int? LastSet = null;

        [HarmonyPostfix]
        public static void OnApplicationTick(float dt)
        {
            if ((Mission.Current != null)
                && (Mission.Current.PlayerTeam != null)
                && (MBCommon.IsPaused != true)
                && (BannerlordCheatsSettings.Instance.PartyHealthRegeneration > 0))
            {
                var now = DateTime.Now.Second;

                if (LastSet == null || now != LastSet)
                {
                    LastSet = now;

                    foreach (var agent in Mission.Current.PlayerTeam.ActiveAgents.Where(x => x.Health > 0))
                    {
                        float health = agent.Health;
                        float maxHealth = agent.HealthLimit;

                        if (health < maxHealth)
                        {
                            float regen = (BannerlordCheatsSettings.Instance.PartyHealthRegeneration / maxHealth) * 100;
                            float newHealth = (float)Math.Round(health + regen);

                            agent.Health = Math.Min(maxHealth, newHealth);
                        }
                    }
                }
            }
        }
    }
}
