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
    public static class NoEnemyLordCombatDeathPatch
    {
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            if (effectedAgent.IsHero()
                && effectedAgent.IsPlayerEnemy()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnemyLordCombatDeathPercentage, out var enemyLordCombatDeathPercentage))
            {
                var factor = enemyLordCombatDeathPercentage / 100f;

                __result *= factor;
            }
        }
    }

    [HarmonyPatch(typeof(DefaultCombatSimulationModel), nameof(DefaultCombatSimulationModel.SimulateHit))]
    public static class NoEnemyLordCombatDeathSimulationPatch
    {
        [HarmonyPostfix]
        public static void SimulateHit(ref CharacterObject strikerTroop, ref CharacterObject struckTroop, ref PartyBase strikerParty, ref PartyBase struckParty, ref float strikerAdvantage, ref MapEvent battle, ref int __result)
        {
            if (struckTroop.IsHero()
                && !struckParty.IsPlayerKingdom()
                && BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnemyLordCombatDeathPercentage, out var enemyLordCombatDeathPercentage))
            {
                var factor = enemyLordCombatDeathPercentage / 100f;

                __result = (int) Math.Round(__result / factor);
            }
        }
    }
}
