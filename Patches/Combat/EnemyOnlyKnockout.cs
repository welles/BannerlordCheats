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
    public static class EnemyOnlyKnockout
    {
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            try
            {
                if (effectedAgent.IsPlayerEnemy()
                    && SettingsManager.EnemyOnlyKnockout.IsChanged)
                {
                    __result = 0f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(EnemyOnlyKnockout));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyOnlyKnockout_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => EnemyOnlyKnockout.GetAgentStateProbability(affectorAgent, effectedAgent, damageType, useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyOnlyKnockout_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => EnemyOnlyKnockout.GetAgentStateProbability(affectorAgent, effectedAgent, damageType, useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class EnemyOnlyKnockout_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => EnemyOnlyKnockout.GetAgentStateProbability(affectorAgent, effectedAgent, damageType, useSurgeryProbability, ref __result);
    }
}
