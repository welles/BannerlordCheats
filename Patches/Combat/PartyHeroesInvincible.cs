using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.Invulnerable), MethodType.Getter)]
    public static class PartyHeroesInvincible
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref bool __result)
        {
            try
            {
                if (__instance.TryGetHuman(out var agent)
                    && !agent.IsPlayer()
                    && agent.Origin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && agent.IsHero()
                    && BannerlordCheatsSettings.Instance?.PartyHeroesInvincible == true)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyHeroesInvincible));
            }
        }
    }
}
