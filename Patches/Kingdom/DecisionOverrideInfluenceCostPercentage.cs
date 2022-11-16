using System;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordCheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultClanPoliticsModel), nameof(DefaultClanPoliticsModel.GetInfluenceRequiredToOverrideKingdomDecision))]
    public static class DecisionOverrideInfluenceCostPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetInfluenceRequiredToOverrideKingdomDecision(
            ref DecisionOutcome popularOption,
            ref DecisionOutcome overridingOption,
            ref KingdomDecision decision,
            ref int __result)
        {
            try
            {
                if (SettingsManager.DecisionOverrideInfluenceCostPercentage.IsChanged)
                {
                    var factor = SettingsManager.DecisionOverrideInfluenceCostPercentage.Value / 100.0f;

                    var newValue = __result * factor;

                    __result = (int) Math.Round(newValue);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(DecisionOverrideInfluenceCostPercentage));
            }
        }
    }
}
