using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches.Inventory
{
    [HarmonyPatch(typeof(DefaultInventoryCapacityModel), nameof(DefaultInventoryCapacityModel.CalculateInventoryCapacity))]
    public static class DefaultInventoryCapacityModelPatch
    {
        [HarmonyPostfix]
        public static void CalculateInventoryCapacity(ref MobileParty mobileParty, ref bool includeDescriptions, ref int additionalTroops, ref int additionalSpareMounts, ref int additionalPackAnimals, ref bool includeFollowers, ref ExplainedNumber __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.ExtraInventoryCapacity, out var extraInventoryCapacity)
                && mobileParty.IsPlayerParty())
            {
                __result.Add(extraInventoryCapacity);
            }
        }
    }
}
