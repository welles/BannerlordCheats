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
        public static void Invulnerable(ref Agent instance, ref Agent.MortalityState result)
        {
            try
            {
                if (instance.IsMount
                    && instance.TryGetHuman(out var rider)
                    && rider.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.PlayerHorseInvincible == true)
                {
                    result = Agent.MortalityState.Invulnerable;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PlayerHorseInvincible));
            }
        }
    }
}
