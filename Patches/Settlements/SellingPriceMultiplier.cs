using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultTradeItemPriceFactorModel), nameof(DefaultTradeItemPriceFactorModel.GetPrice))]
    public static class SellingPriceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPrice(EquipmentElement itemRosterElement, MobileParty clientParty, PartyBase merchant, bool isSelling, float inStoreValue, float supply, float demand, ref int result)
        {
            try
            {
                if (clientParty.IsPlayerParty()
                    && isSelling
                    && BannerlordCheatsSettings.Instance?.SellingPriceMultiplier > 1f)
                {
                    result = (int) Math.Round(result * BannerlordCheatsSettings.Instance.SellingPriceMultiplier);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(SellingPriceMultiplier));
            }
        }
    }
}
