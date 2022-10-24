using System;
using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordCheats.Patches.Inventory
{
    [HarmonyPatch(typeof(DefaultInventoryCapacityModel), nameof(DefaultInventoryCapacityModel.CalculateInventoryCapacity))]
    public static class ExtraInventoryCapacity
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateInventoryCapacity(ref MobileParty mobileParty, ref bool includeDescriptions, ref int additionalTroops, ref int additionalSpareMounts, ref int additionalPackAnimals, ref bool includeFollowers, ref ExplainedNumber result)
        {
            try
            {
                if (mobileParty.IsPlayerParty()
                    && BannerlordCheatsSettings.Instance?.ExtraInventoryCapacity > 0)
                {
                    result.Add(BannerlordCheatsSettings.Instance.ExtraInventoryCapacity);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraInventoryCapacity));
            }
        }
    }
}
