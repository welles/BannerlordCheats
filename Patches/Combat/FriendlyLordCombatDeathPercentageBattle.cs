using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class FriendlyLordCombatDeathPercentageBattle
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
        {
            try
            {
                if (effectedAgent.IsHero()
                    &&effectedAgent.IsPlayerAlly()
                    && BannerlordCheatsSettings.Instance?.FriendlyLordCombatDeathPercentage < 100f)
                {
                    var factor = BannerlordCheatsSettings.Instance.FriendlyLordCombatDeathPercentage / 100f;

                    __result *= factor;
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(FriendlyLordCombatDeathPercentageBattle));
            }
        }
    }
}
