using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class NoFriendlyLordCombatDeathPatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (effectedAgent.IsHero()
                &&effectedAgent.IsPlayerAlly()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.FriendlyLordCombatDeathPercentage, out var friendlyLordCombatDeathPercentage))
            {
                var factor = friendlyLordCombatDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }

    [HarmonyPatch(typeof(DefaultCombatSimulationModel), nameof(DefaultCombatSimulationModel.SimulateHit))]
    public static class NoFriendlyLordCombatDeathSimulationPatch
    {
        [HarmonyPostfix]
        public static void SimulateHit(ref CharacterObject strikerTroop, ref CharacterObject struckTroop, ref PartyBase strikerParty, ref PartyBase struckParty, ref float strikerAdvantage, ref MapEvent battle, ref int __result)
        {
            if (struckTroop.IsHero()
                && struckParty.IsPlayerKingdom()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.FriendlyLordCombatDeathPercentage, out var friendlyLordCombatDeathPercentage))
            {
                var factor = friendlyLordCombatDeathPercentage / 100f;

                __result = (int) Math.Round(__result / factor);
            }
        }
    }
}
