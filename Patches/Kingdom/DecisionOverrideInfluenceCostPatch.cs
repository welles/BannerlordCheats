using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultClanPoliticsModel), nameof(DefaultClanPoliticsModel.GetInfluenceRequiredToOverrideKingdomDecision))]
    public static class DecisionOverrideInfluenceCostPatch
    {
        [HarmonyPostfix]
        public static void GetInfluenceRequiredToOverrideKingdomDecision(
            ref DecisionOutcome popularOption,
            ref DecisionOutcome overridingOption,
            ref KingdomDecision decision,
            ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.DecisionOverrideInfluenceCostPercentage < 100.0f)
            {
                var factor = BannerlordCheatsSettings.Instance.DecisionOverrideInfluenceCostPercentage / 100.0f;

                var newValue = __result * factor;

                __result = (int) Math.Round(newValue);
            }
        }
    }
}
