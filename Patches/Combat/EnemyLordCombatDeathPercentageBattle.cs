using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using StoryMode.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    public static class EnemyLordCombatDeathPercentageBattle
    {
        public static void GetAgentStateProbability(
            ref Agent affectorAgent,
            ref Agent effectedAgent,
            ref DamageTypes damageType,
            ref float useSurgeryProbability,
            ref float __result)
        {
            try
            {
                if (effectedAgent.IsHero()
                    && effectedAgent.IsPlayerEnemy()
                    && SettingsManager.EnemyLordCombatDeathPercentage.IsChanged)
                {
                    var factor = SettingsManager.EnemyLordCombatDeathPercentage.Value / 100f;

                    __result *= factor;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemyLordCombatDeathPercentageBattle));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathPercentageBattle_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(
            ref Agent affectorAgent,
            ref Agent effectedAgent,
            ref DamageTypes damageType,
            ref float useSurgeryProbability,
            ref float __result)
            => EnemyLordCombatDeathPercentageBattle.GetAgentStateProbability(
                ref affectorAgent,
                ref effectedAgent,
                ref damageType,
                ref useSurgeryProbability,
                ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathPercentageBattle_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(
            ref Agent affectorAgent,
            ref Agent effectedAgent,
            ref DamageTypes damageType,
            ref float useSurgeryProbability,
            ref float __result)
            => EnemyLordCombatDeathPercentageBattle.GetAgentStateProbability(
                ref affectorAgent,
                ref effectedAgent,
                ref damageType,
                ref useSurgeryProbability,
                ref __result);
    }

    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyLordCombatDeathPercentageBattle_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(
            ref Agent affectorAgent,
            ref Agent effectedAgent,
            ref DamageTypes damageType,
            ref float useSurgeryProbability,
            ref float __result)
            => EnemyLordCombatDeathPercentageBattle.GetAgentStateProbability(
                ref affectorAgent,
                ref effectedAgent,
                ref damageType,
                ref useSurgeryProbability,
                ref __result);
    }
}
