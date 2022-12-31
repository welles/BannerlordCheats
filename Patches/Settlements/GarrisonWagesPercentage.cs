using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class GarrisonWagesPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetTotalWage(ref MobileParty mobileParty, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (mobileParty.IsGarrison
                    && mobileParty.IsPlayerParty()
                    && SettingsManager.GarrisonWagesPercentage.IsChanged)
                {
                    __result.AddPercentage(SettingsManager.GarrisonWagesPercentage.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(GarrisonWagesPercentage));
            }
        }
    }
}
