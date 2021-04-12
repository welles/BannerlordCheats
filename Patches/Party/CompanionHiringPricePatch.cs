using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultCompanionHiringPriceCalculationModel), nameof(DefaultCompanionHiringPriceCalculationModel.GetCompanionHiringPrice))]
    public static class CompanionHiringPricePatch
    {
        [HarmonyPostfix]
        public static void GetCompanionHiringPrice(Hero companion, ref int __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.FreeCompanionHiring, out var freeCompanionHiring)
                && freeCompanionHiring)
            {
                __result = 0;
            }
        }
    }
}
