using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.CurrentMortalityState), MethodType.Getter)]
    public static class PlayerHorseInvincible
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref Agent.MortalityState __result)
        {
            try
            {
                if (__instance.IsMount
                    && __instance.TryGetHuman(out var rider)
                    && rider.IsPlayer()
                    && SettingsManager.PlayerHorseInvincible.IsChanged)
                {
                    __result = Agent.MortalityState.Invulnerable;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PlayerHorseInvincible));
            }
        }
    }
}
