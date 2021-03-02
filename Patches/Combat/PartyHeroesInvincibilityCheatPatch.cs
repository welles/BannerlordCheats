using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class PartyHeroesInvincibilityCheatPatch
    {
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            if (!BannerlordCheatsSettings.Instance.PartyHeroesInvincible) return;
            if (__instance.TryGetHuman(out var agent) && agent.IsHero && agent.Team?.IsPlayerTeam == true)
            {
                __result = true;
                return;
            }
        }
    }
}
