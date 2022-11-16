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
    public static class PartyOnlyKnockout
    {
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            try
            {
                if (effectedAgent.Origin.TryGetParty(out var party)
                    && party.IsPlayerParty()
                    && !effectedAgent.IsPlayer()
                    && SettingsManager.PartyOnlyKnockout.IsChanged)
                {
                    __result = 0f;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(PartyOnlyKnockout));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class PartyOnlyKnockout_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => PartyOnlyKnockout.GetAgentStateProbability(affectorAgent, effectedAgent, damageType, useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class PartyOnlyKnockout_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => PartyOnlyKnockout.GetAgentStateProbability(affectorAgent, effectedAgent, damageType, useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class PartyOnlyKnockout_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => PartyOnlyKnockout.GetAgentStateProbability(affectorAgent, effectedAgent, damageType, useSurgeryProbability, ref __result);
    }
}
