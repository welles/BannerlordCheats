using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultInventoryCapacityModel), "CalculateInventoryCapacity")]
    public static class DefaultInventoryCapacityModelPatch
    {
        [HarmonyPostfix]
        public static void CalculateInventoryCapacity(MobileParty mobileParty, StatExplainer explanation, int additionalTroops, int additionalSpareMounts, int additionalPackAnimals, bool includeFollowers, ref int __result)
        {
            if ((mobileParty?.IsMainParty ?? false) && BannerlordCheatsSettings.Instance.ModifyInventoryCapacity)
            {
                __result = BannerlordCheatsSettings.Instance.InventoryCapacity;
            }
        }
    }
}
