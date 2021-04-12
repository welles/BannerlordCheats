using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class PlayerHorseInvinciblePatch
    {
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.PlayerHorseInvincible, out var playerHorseInvincible)
                && playerHorseInvincible
                && __instance.IsMount
                && __instance.TryGetHuman(out var rider)
                && rider.IsPlayer())
            {
                __result = true;
            }
        }
    }
}
