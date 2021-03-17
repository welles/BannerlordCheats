using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class PartyHeroesInvincibilityCheatPatch
    {
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            if (BannerlordCheatsSettings.Instance.PartyHeroesInvincible
                && __instance.TryGetHuman(out var agent)
                && agent.Origin.TryGetParty(out var party)
                && party.IsPlayerParty()
                && agent.IsHero)
            {
                __result = true;
            }
        }
    }
}
