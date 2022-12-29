using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class TroopWagesPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetTotalWage(ref MobileParty mobileParty, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (mobileParty.IsPlayerParty()
                    && SettingsManager.TroopWagesPercentage.IsChanged)
                {
                    __result.AddPercentage(SettingsManager.TroopWagesPercentage.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(TroopWagesPercentage));
            }
        }
    }
}
