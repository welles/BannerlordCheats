using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using JetBrains.Annotations;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class HealthRegeneration
    {
        private static int? _lastSet;

        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (Mission.Current == null
                    || Agent.Main == null
                    || MBCommon.IsPaused
                    || !(BannerlordCheatsSettings.Instance?.HealthRegeneration > 0f)) return;
                var now = DateTime.Now.Second;

                if (now == _lastSet) return;
                _lastSet = now;

                float health = Agent.Main.Health;
                float maxHealth = Agent.Main.HealthLimit;

                if (!(health < maxHealth)) return;
                float regen = (BannerlordCheatsSettings.Instance.HealthRegeneration / maxHealth) * 100;
                float newHealth = (float) Math.Round(health + regen);

                Agent.Main.Health = Math.Min(maxHealth, newHealth);
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(HealthRegeneration));
            }
        }
    }
}
