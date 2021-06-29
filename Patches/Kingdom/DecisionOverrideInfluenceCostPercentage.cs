using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultClanPoliticsModel), nameof(DefaultClanPoliticsModel.GetInfluenceRequiredToOverrideKingdomDecision))]
    public static class DecisionOverrideInfluenceCostPercentage
    {
        [HarmonyPostfix]
        public static void GetInfluenceRequiredToOverrideKingdomDecision(
            ref DecisionOutcome popularOption,
            ref DecisionOutcome overridingOption,
            ref KingdomDecision decision,
            ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.DecisionOverrideInfluenceCostPercentage, out var decisionOverrideInfluenceCostPercentage))
            {
                var factor = decisionOverrideInfluenceCostPercentage / 100.0f;

                var newValue = __result * factor;

                __result = (int) Math.Round(newValue);
            }
        }
    }
}
