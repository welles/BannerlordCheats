using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(Agent), nameof(Agent.CurrentMortalityState), MethodType.Getter)]
    public static class PartyInvincible
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Invulnerable(ref Agent __instance, ref Agent.MortalityState __result)
        {
            try
            {
                if (__instance.TryGetHuman(out var agent)
                    && agent.Origin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && !agent.IsHero()
                    && SettingsManager.PartyInvincible.IsChanged)
                {
                    __result = Agent.MortalityState.Invulnerable;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyInvincible));
            }
        }
    }
}
