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
        public static void CalculateInventoryCapacity(ref MobileParty mobileParty, ref bool includeDescriptions, ref int additionalTroops, ref int additionalSpareMounts, ref int additionalPackAnimals, ref bool includeFollowers, ref ExplainedNumber __result)
        {
            try
            {
                if (mobileParty.IsPlayerParty()
                    && SettingsManager.ExtraInventoryCapacity.IsChanged)
                {
                    __result.Add(SettingsManager.ExtraInventoryCapacity.Value);
                }
            }
            catch (Exception e)
            {
                SubModule.LogError(e, typeof(ExtraInventoryCapacity));
            }
        }
    }
}
