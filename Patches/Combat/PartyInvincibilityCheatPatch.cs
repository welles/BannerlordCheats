using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class PartyInvincibilityCheatPatch
    {
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            if ((__instance?.Team?.IsPlayerTeam ?? false)
                && BannerlordCheatsSettings.Instance.PartyInvincible)
            {
                __result = true;
            }
        }
    }
}
