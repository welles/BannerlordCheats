using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTotalWage))]
    public static class GarrisonWagesPatch
    {
        [HarmonyPostfix]
        public static void GetTotalWage(ref MobileParty mobileParty, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (mobileParty.IsGarrison
                && (mobileParty.Party?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.GarrisonWagesPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.GarrisonWagesPercentage / 100f;

                __result.AddFactor(factor);
            }
        }
    }
}
