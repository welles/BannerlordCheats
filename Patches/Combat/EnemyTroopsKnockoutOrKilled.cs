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
    public static class EnemyTroopsKnockoutOrKilled
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
                if (!effectedAgent.IsHero
                    && effectedAgent.IsPlayerEnemy()
                    && SettingsManager.EnemyTroopsKnockoutOrKilled.IsChanged)
                {
                    if (SettingsManager.EnemyTroopsKnockoutOrKilled.Value == KnockoutOrKilled.Killed)
                    {
                        __result = 1.0f;
                    }
                    else if (SettingsManager.EnemyTroopsKnockoutOrKilled.Value == KnockoutOrKilled.Knockout)
                    {
                        __result = 0.0f;
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemyTroopsKnockoutOrKilled));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyTroopsKnockoutOrKilled_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => EnemyTroopsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyTroopsKnockoutOrKilled_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => EnemyTroopsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyTroopsKnockoutOrKilled_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => EnemyTroopsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }
}