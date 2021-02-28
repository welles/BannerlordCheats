using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class SellingPriceMultiplier
    {
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int __result)
        {
            if ((clientParty?.IsMainParty ?? false)
                && isSelling
                && BannerlordCheatsSettings.Instance.SellingPriceMultiplier > 1)
            {
                __result *= BannerlordCheatsSettings.Instance.SellingPriceMultiplier;
            }
        }
    }
}
