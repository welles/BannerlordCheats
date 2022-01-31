using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class SellingPriceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int __result)
        {
            try
            {
                if (clientParty.IsPlayerParty()
                    && isSelling
                    && BannerlordCheatsSettings.Instance?.SellingPriceMultiplier > 1f)
                {
                    __result = (int) Math.Round(__result * BannerlordCheatsSettings.Instance.SellingPriceMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SellingPriceMultiplier));
            }
        }
    }
}
