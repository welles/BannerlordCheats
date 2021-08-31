using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class PlayerHorseInvincible
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            if (__instance.IsMount
                && __instance.TryGetHuman(out var rider)
                && rider.IsPlayer()
                && BannerlordCheatsSettings.Instance?.PlayerHorseInvincible == true)
            {
                __result = true;
            }
        }
    }
}
