using BannerlordCheats.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class TradeCostPercentage
    {
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int __result)
        {
            if ((clientParty?.IsMainParty ?? false)
                && !isSelling)
            {
                var factor = BannerlordCheatsSettings.Instance.ItemTradingCostPercentage / 100f;

                var newValue = (int)Math.Round(factor * __result);

                __result = newValue;
            }
        }
    }
}
