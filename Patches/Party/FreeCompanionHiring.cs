using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultCompanionHiringPriceCalculationModel), nameof(DefaultCompanionHiringPriceCalculationModel.GetCompanionHiringPrice))]
    public static class FreeCompanionHiring
    {
        [HarmonyPostfix]
        public static void GetCompanionHiringPrice(Hero companion, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance?.FreeCompanionHiring == true)
            {
                __result = 0;
            }
        }
    }
}
