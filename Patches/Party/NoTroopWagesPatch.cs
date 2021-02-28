using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class NoTroopWagesPatch
    {
        [HarmonyPostfix]
        public static void GetTotalWage(ref MobileParty mobileParty, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if ((mobileParty?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.TroopWagesPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.TroopWagesPercentage / 100f;

                __result.AddFactor(factor);
            }
        }
    }
}
