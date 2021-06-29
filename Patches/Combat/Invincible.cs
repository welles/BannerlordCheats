using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class Invincible
    {
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.Invincible, out var invincible)
                && invincible
                && __instance.IsPlayer())
            {
                __result = true;
            }
        }
    }
}
