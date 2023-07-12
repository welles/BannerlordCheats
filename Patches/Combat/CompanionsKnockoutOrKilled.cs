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
    public static class CompanionsKnockoutOrKilled
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
                if (effectedAgent.IsPlayerCompanion()
                    && SettingsManager.CompanionsKnockoutOrKilled.IsChanged)
                {
                    if (SettingsManager.CompanionsKnockoutOrKilled.Value == KnockoutOrKilled.Killed)
                    {
                        __result = 1.0f;
                    }
                    else if (SettingsManager.CompanionsKnockoutOrKilled.Value == KnockoutOrKilled.Knockout)
                    {
                        __result = 0.0f;
                    }
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(CompanionsKnockoutOrKilled));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class CompanionsKnockoutOrKilled_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => CompanionsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class CompanionsKnockoutOrKilled_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => CompanionsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class CompanionsKnockoutOrKilled_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => CompanionsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }
}