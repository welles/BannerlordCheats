using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultCompanionHiringPriceCalculationModel), "GetCompanionHiringPrice")]
    public static class CompanionHiringPricePatch
    {
        [HarmonyPostfix]
        public static void GetCompanionHiringPrice(Hero companion, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.FreeCompanionHiring)
            {
                __result = 0;
            }
        }
    }
}
