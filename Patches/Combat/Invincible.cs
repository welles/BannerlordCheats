using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.CurrentMortalityState), MethodType.Getter)]
    public static class Invincible
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent instance, ref Agent.MortalityState result)
        {
            try
            {
                if (instance.IsPlayer()
                    && BannerlordCheatsSettings.Instance?.Invincible == true)
                {
                    result = Agent.MortalityState.Invulnerable;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(Invincible));
            }
        }
    }
}
